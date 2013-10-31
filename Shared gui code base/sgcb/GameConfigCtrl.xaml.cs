﻿using System;
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
    /// Interaction logic for GameConfig.xaml
    /// </summary>
    public partial class GameConfigCtrl : UserControl
    {
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
                foreach (GameBoard map in Storage.settings.maps)
                {
                    MapList.Items.Add(map.level);
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
                    GameBoard board = Storage.settings.maps[int.Parse(MapList.SelectedItem.ToString())];
                    gameboard.init(DisplayMode.Play, board);

                    // show gameboardctrl
                    InvalidateVisual();
                }
            }
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
            // if gameboard is not null
            if (gameboard != null)
            { 
            
            }
            // leave for now
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