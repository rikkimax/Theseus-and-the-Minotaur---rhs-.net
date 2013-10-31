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
using System.Windows.Threading;
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

        public delegate void EntityClashDelegate();
        public event EntityClashDelegate EntityTouched;
        public event EntityClashDelegate TheseusExited;

        public GameBoardCtrl()
        {
            InitializeComponent();
            cells = new List<CellCtrl>();
            entities = new Dictionary<EntityType, Point>();
        }

        /*
         * TODO Make sure to call this before usage!
         * TODO Maybe do some checks for that...
         * TODO Check that all inputs are valid.
         */
        public void init(DisplayMode mode, GameBoard board)
        {
            entities.Clear();

            entities.Add(EntityType.Theseus, new Point(board.theseus.startX, board.theseus.startY));
            entities.Add(EntityType.Minotaur, new Point(board.minotaur.startX, board.minotaur.startY));

            this.mode = mode;
            this.board = board;

            InvalidateVisual();
            Focus();
        }

        public void reinit()
        {
            entities[EntityType.Theseus] = new Point(board.theseus.startX, board.theseus.startY);
            entities[EntityType.Minotaur] = new Point(board.minotaur.startX, board.minotaur.startY);
            InvalidateVisual();
        }

        void setMinotaur(byte x, byte y)
        {
            entities.Add(EntityType.Minotaur, new Point(x, y));
        }

        void setTheseus(byte x, byte y)
        {
            entities.Add(EntityType.Theseus, new Point(x, y));
        }

        private GameBoard board;
        
        public GameBoard GetBoard()
        {
            return board;
        }

        public void SetBoard(GameBoard board)
        {
            this.board = board;
            InvalidateVisual();
        }

        private byte cellsX;
        private byte cellsY;
        private DisplayMode mode;

        protected override void OnRender(DrawingContext drawingContext)
        {
            bool needUpdatedCells = false;
            if (board == null)
            {
                needUpdatedCells = false;
            } 
            else
            {
                needUpdatedCells = board.cells.Count != cells.Count;
                // do we need more conditions?
                needUpdatedCells = true;
            }
            int location;

            // TODO has the size of render window been changed?
            // if so need to update all cells sizes.

            if (needUpdatedCells)
            {
                grid.Children.Clear();
                cellsX = (byte)board.width;
                cellsY = (byte)board.height;

                if (board.cells.Count != cells.Count)
                {
                    grid.RowDefinitions.Clear();
                    grid.ColumnDefinitions.Clear();

                    for (uint i = 0; i < cellsY; i++)
                    {
                        var rowDefinition = new RowDefinition();
                        rowDefinition.Height = GridLength.Auto;
                        grid.RowDefinitions.Add(rowDefinition);
                    }

                    for (uint i = 0; i < cellsX; i++)
                    {
                        var colDefinition = new ColumnDefinition();
                        colDefinition.Width = GridLength.Auto;
                        grid.ColumnDefinitions.Add(colDefinition);
                    }

                    if (board.cells.Count > cells.Count)
                    {
                        ushort toadd = (ushort)(board.cells.Count - cells.Count);
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

                for (byte curX = 0; curX < cellsX; curX++)
                {
                    for (byte curY = 0; curY < cellsY; curY++)
                    {
                        // set grid items size
                        grid.Children.Add(cells[cur]);
                        Grid.SetColumn(cells[cur], curY);
                        Grid.SetRow(cells[cur], curX);

                        cur++;
                    }
                }

                needUpdatedCells = false;
            }

            if (board != null)
            {

                for (location = 0; location < cells.Count; location++)
                {
                    cells[location].data = board.cells[location];
                    cells[location].withEntity = EntityType.None;
                }

                // TODO note this is not a true wall determination for left and up.
                // Maybe this should be fixed?
                for (byte cur = 0; cur < cellsX * cellsY; cur += cellsX)
                {
                    cells[cur].hasLeftWall = true;
                }
                for (byte cur = 0; cur < cellsY; cur++)
                {
                    cells[cur].hasUpWall = true;
                }

                location = (int)((entities[EntityType.Theseus].Y * cellsX) + entities[EntityType.Theseus].X);
                cells[location].withEntity = EntityType.Theseus;

                location = (int)((entities[EntityType.Minotaur].Y * cellsX) + entities[EntityType.Minotaur].X);
                cells[location].withEntity = EntityType.Minotaur;
            }

            if (board == null)
            {
                grid.Children.Clear();
                cells.Clear();
            }

            base.OnRender(drawingContext);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            // say what about stopping spamming of key presses?
            // maybe we should throttle that..

            if (mode == DisplayMode.Play)
            {
                Direction directionToMove = Direction.Omit;
                bool makeMove = true;

                // shouldn't we send off to an algorithym about e.g. a move?
                // also is keys bindable?

                switch (e.Key)
                {
                    case Key.Left:
                        // left arrow
                        directionToMove = Direction.Left;
                        break;
                    case Key.Right:
                        // right arrow
                        directionToMove = Direction.Right;
                        break;
                    case Key.Up:
                        // up arrow
                        directionToMove = Direction.Up;
                        break;
                    case Key.Down:
                        // down arrow
                        directionToMove = Direction.Down;
                        break;
                    case Key.Space:
                        // how about skipping a turn?
                        //directionToMove = Direction.Omit; // waste of code as its already default
                        break;
                    default:
                        // ignore this case (could be anything)
                        makeMove = false;
                        break;
                }

                // so.. now lets go change the data models with the new moves.
                // that we may or may not be able to make. We'd know if we checked the return value.
                if (makeMove)
                {
                    if (MakeMove.TheseusTurn(ref board, ref entities, directionToMove))
                    {
                        // TODO redraw
                        InvalidateVisual();
                    }
                }

                if (entities[EntityType.Theseus].ToString() == entities[EntityType.Minotaur].ToString())
                {
                    EntityTouched();
                }
                else
                {
                    foreach (Cell cell in board.cells)
                    {
                        if (cell.x == entities[EntityType.Theseus].X && cell.y == entities[EntityType.Theseus].Y && cell.isExit)
                        {
                            TheseusExited();
                            break;
                        }
                    }
                }
            }
            else if (mode == DisplayMode.Design)
            {
                // explicitly saying this instead of else'ing. It _should_ be optimized out.
                // good practice.

                // anything specific required for design key wise?
            }
            base.OnPreviewKeyDown(e);
        }
    }
}
