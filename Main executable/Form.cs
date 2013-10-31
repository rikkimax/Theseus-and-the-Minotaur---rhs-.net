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
using TATM.SGCB;

namespace TATM.ME
{
    public partial class PlayForm : Form
    {
        public PlayForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Storage.Load();

            if (Storage.settings == null || Storage.settings.maps.Count == 0)
            {
                GameSettings settings = new GameSettings();

                GameBoard board = new GameBoard();
                board.level = 0;
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

                settings.maps.Add(board);

                board = new GameBoard();
                board.level = 1;
                board.minotaur = new Entity(1, 2);
                board.theseus = new Entity(1, 0);
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

                settings.maps.Add(board);

                Storage.settings = settings;

                Storage.Save();
            }

            gameConfigCtrl1.init(gameBoardCtrl1);

            //gameBoardCtrl1.init(DisplayMode.Play, board);
            gameBoardCtrl1.EntityTouched += new GameBoardCtrl.EntityClashDelegate(EntityClashEvent);
            gameBoardCtrl1.TheseusExited += new GameBoardCtrl.EntityClashDelegate(EntityExited);
            gameConfigCtrl1.RunPlayerForm += new GameConfigCtrl.RunPlayerFormDelegate(PlayerFormShow);

            Width = Width + 1;
            Width = Width - 1;
        }

        public void EntityClashEvent()
        {
            // Theseus and Minotaur has been caught.

            System.Console.WriteLine("Dinner time!");
            gameBoardCtrl1.reinit();
        }

        public void EntityExited()
        {
            // Theseus has exited the level.
            if (gameConfigCtrl1.GetLevel() + 1 >= Storage.settings.maps.Count)
            {
                gameBoardCtrl1.SetBoard(null);
                // end of maps
            }
            else
            {
                gameConfigCtrl1.SetLevel(gameConfigCtrl1.GetLevel() + 1);
            }
        }

        protected PlayerForm playerForm;

        public void SetPlayerForm(PlayerForm value)
        {
            playerForm = value;
        }

        void PlayerFormShow()
        {
            Hide();
            Visible = false;
            playerForm.Visible = true;
        }
    }
}
