using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TATM.SGCB;
using TATM.SCB;
using TATM.SCB.models;

namespace TATM.ME
{
    public partial class PlayerForm : Form
    {
        protected PlayForm play;

        public PlayerForm()
        {
            InitializeComponent();
            playerCtrl1.RunPlayForm += new PlayerCtrl.RunPlayFormDelegate(runMainForm);

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

                Player player = new Player();
                player.name = Environment.UserName;
                settings.players.Add(player);

                Storage.settings = settings;
                Storage.currentPlayer = player;

                Storage.Save();
            }

            Storage.currentPlayer = Storage.settings.players.Find(delegate(Player player)
            {
                return player.name == Environment.UserName;
            });
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            runMainForm();
        }

        void runMainForm()
        {
            Visible = false;
            play = new PlayForm();
            play.ShowDialog();
            Visible = true;
        }
    }
}
