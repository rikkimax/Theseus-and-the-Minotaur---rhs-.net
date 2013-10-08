using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TATM.SCB;
using TATM.SCB.models;

namespace TATM.SGCB
{
    /// <summary>
    /// Interaction logic for GameBoardCtrl.xaml
    /// </summary>
    public partial class GameBoardCtrl : UserControl
    {
        List<CellCtrl> cells;
        Dictionary<EntityType, Point> entities;

        public GameBoardCtrl()
        {
            InitializeComponent();
        }

        /*
         * TODO Make sure to call this before usage!
         * TODO Maybe do some checks for that...
         * TODO Check that all inputs are valid.
         */
        public void init(DisplayMode mode, GameBoard board)
        {
            cells = new List<CellCtrl>();
            entities = new Dictionary<EntityType, Point>();
            entities.Add(EntityType.Theseus, new Point(board.theseus.startX, board.theseus.startY));
            entities.Add(EntityType.Minotaur, new Point(board.minotaur.startX, board.minotaur.startY));

            this.mode = mode;
            this.board = board;
        }

        void setMinotaur(byte x, byte y)
        {
            entities.Add(EntityType.Minotaur, new Point(x, y));
        }

        void setTheseus(byte x, byte y)
        {
            entities.Add(EntityType.Theseus, new Point(x, y));
        }

        public GameBoard board { get; set; }

        private byte cellsX;
        private byte cellsY;
        private DisplayMode mode;

        protected override void OnRender(DrawingContext drawingContext)
        {
            bool needUpdatedCells = board.cells.Count != cells.Count;
            int location;
            // do we need more conditions?
            
            // TODO has the size of render window been changed?
            // if so need to update all cells sizes.

            if (needUpdatedCells)
            {
                grid.Children.Clear();
                cellsX = (byte)board.width;
                cellsY = (byte)board.height;

                if (board.cells.Count != cells.Count)
                {
                    if (board.cells.Count > cells.Count)
                    {
                        ushort toadd = (ushort)(board.cells.Count - cells.Count);
                        Console.Write("Adding cell count "); Console.WriteLine(toadd);
                        for (uint i = 0; i < toadd; i++)
                        {
                            CellCtrl cell = new CellCtrl();
                            cell.mode = mode;
                            cells.Add(cell);
                        }
                    }
                    else
                    {
                        ushort toremove = (ushort)(cells.Count - board.cells.Count);
                        cells.RemoveRange(cells.Count - toremove, toremove);
                    }
                }

                ushort cur = 0;

                for (byte curX = 0; curX < cellsX; curX++) {
                    for (byte curY = 0; curY < cellsY; curY++)
                    {
                        // set grid items size

                        grid.Children.Add(cells[cur]);
                        Grid.SetColumn(cells[cur], curX);
                        Grid.SetRow(cells[cur], curY);

                        cur++;
                    }
                }

                needUpdatedCells = false;
            }

            for (location = 0; location < cells.Count; location++)
            {
                cells[location].data = board.cells[location];
                cells[location].withEntity = EntityType.None;
            }

            location = (int)((entities[EntityType.Theseus].Y * cellsY) + entities[EntityType.Theseus].X);
            cells[location].withEntity = EntityType.Theseus;

            location = (int)((entities[EntityType.Minotaur].Y * cellsY) + entities[EntityType.Minotaur].X);
            cells[location].withEntity = EntityType.Minotaur;

            base.OnRender(drawingContext);
        }
    }
}
