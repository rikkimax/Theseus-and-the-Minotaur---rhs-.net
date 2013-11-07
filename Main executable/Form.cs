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
            gameConfigCtrl1.init(gameBoardCtrl1);

            //gameBoardCtrl1.init(DisplayMode.Play, board);
            gameBoardCtrl1.EntityTouched += new GameBoardCtrl.EntityClashDelegate(EntityClashEvent);
            gameBoardCtrl1.TheseusExited += new GameBoardCtrl.EntityClashDelegate(EntityExited);
            gameBoardCtrl1.MoveTaken += new GameBoardCtrl.MoveTakenDelegate(MoveTaken);
            gameConfigCtrl1.RunPlayerForm += new GameConfigCtrl.RunPlayerFormDelegate(PlayerFormShow);

            Width = Width + 1;
            Width = Width - 1;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }

        public void EntityClashEvent()
        {
            // Theseus and Minotaur has been caught.
            numberOfMoves = 0;
            System.Console.WriteLine("Dinner time!");
            gameBoardCtrl1.reinit();
        }

        public void EntityExited()
        {
            if (Storage.currentPlayer != null)
            {
                Storage.currentPlayer.unlockMapLevel = (uint)gameConfigCtrl1.GetLevel() + 1;
                double time = (double)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
                double value = (numberOfMoves / (time - gameBoardCtrl1.time)) * gameBoardCtrl1.GetBoard().cells.Count;
                if (value > Storage.currentPlayer.highscore || Storage.currentPlayer.highscore == 0)
                {
                    Storage.currentPlayer.highscore = value;
                }
                numberOfMoves = 0;
                Storage.Save();
                gameConfigCtrl1.SetLevel((int)Storage.currentPlayer.unlockMapLevel);
            }
            
            // Theseus has exited the level.
            if (Storage.currentPlayer.unlockMapLevel >= Storage.settings.maps.Count)
            {
                gameBoardCtrl1.SetBoard(null);
                // end of maps
            }
            else
            {
                gameConfigCtrl1.SetLevel((int)Storage.currentPlayer.unlockMapLevel);
            }
        }

        protected uint numberOfMoves;

        public void MoveTaken()
        {
            numberOfMoves++;
        }

        void PlayerFormShow()
        {
            Visible = false;
        }
    }
}
