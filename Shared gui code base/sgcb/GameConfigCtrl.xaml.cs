using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GameConfig.xaml
    /// </summary>
    public partial class GameConfigCtrl : UserControl
    {
        public delegate void RunPlayerFormDelegate();
        public event RunPlayerFormDelegate RunPlayerForm;

        public GameConfigCtrl()
        {
            InitializeComponent();
        }

        public void init(GameBoardCtrl gameboard)
        {
            // set gameboard to this
            this.gameboard = gameboard;
            InvalidateVisual();
        }
        protected GameBoardCtrl gameboard;


        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameboard != null)
            {
                MapList.Items.Clear();

                // foreach map list add to list
                //  MapList.Items.Add("map id");
                int i = -1;
                foreach (GameBoard map in Storage.settings.maps)
                {
                    if (Storage.currentPlayer == null || i < Storage.currentPlayer.unlockMapLevel)
                        MapList.Items.Add(map.level);
                    i++;
                }

            }
            base.OnRender(drawingContext);
        }

        private void MapList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameboard != null)
            {
                // e.AddedItems gets the items selected
                // tell gameboardctrl new gameboard
                if (MapList.SelectedItem != null)
                {
                    level = int.Parse(MapList.SelectedItem.ToString());
                    GameBoard board = Storage.settings.maps[level];
                    gameboard.init(DisplayMode.Play, board);

                    // show gameboardctrl
                    InvalidateVisual();
                }
            }
        }

        protected int level;

        public void SetLevel(int level)
        {
            if (Storage.settings.maps.Count > level && level >= 0)
            {
                GameBoard board = Storage.settings.maps[level];
                gameboard.init(DisplayMode.Play, board);
                this.level = level;
                InvalidateVisual();
            }
        }

        public int GetLevel()
        {
            return level;
        }

        private void PlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            // if gameboard is not null
            /*if (gameboard != null)
            {
                //leave for now
            }
            */
            // show new window
            // leave for now
            RunPlayerForm();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            // if gameboard is not null
            if (gameboard != null)
            {
                Storage.Load();
                InvalidateVisual();
            }

            // get the storage manager to load
            // tell the gameboard to hide
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // if gameboard is not null
            if (gameboard != null)
            {
                Storage.Save();
            }

            // get the storage manager to save.
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "editor.exe";
            try
            {
                p.Start();
                p.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception w32e)
            {
                MessageBox.Show("Could not open editor", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            if (gameboard != null)
            {
                gameboard.Focus();
            }
            base.OnGotFocus(e);
        }
    }
}
