using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TATM.SCB;
using TATM.SCB.models;

namespace TATM.ME
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            board = new GameBoard();
            board.minotaur = new Entity(1, 0);
            board.theseus = new Entity(1, 2);
            board.width = 3;
            board.height = 3;
            board.cells = new List<Cell>();
            
            board.cells.Add(new Cell(0, 0, new Border(false, false), false, false));
            board.cells.Add(new Cell(1, 0, new Border(false, true), false, false));
            board.cells.Add(new Cell(2, 0, new Border(true, false), false, false));

            board.cells.Add(new Cell(0, 1, new Border(false, false), false, false));
            board.cells.Add(new Cell(1, 1, new Border(true, true), false, false));
            board.cells.Add(new Cell(2, 1, new Border(true, false), true, false));

            board.cells.Add(new Cell(0, 2, new Border(false, true), false, false));
            board.cells.Add(new Cell(1, 2, new Border(false, true), false, false));
            board.cells.Add(new Cell(2, 2, new Border(true, true), false, false));

            gameBoardCtrl1.init(DisplayMode.Play, board);

            Width = Width + 1;
        }

        public GameBoard board;
    }
}
