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
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            MapList.Items.Clear();

            // foreach map list add to list
            //  MapList.Items.Add("map id");
            
            base.OnRender(drawingContext);
        }

        private void MapList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // e.AddedItems gets the items selected
            // tell gameboardctrl new gameboard
            // show gameboardctrl
        }

        private void PlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            // if gameboard is not null

            // show new window
            // leave for now
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            // if gameboard is not null

            // get the storage manager to load
            // tell the gameboard to hide
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // if gameboard is not null

            // get the storage manager to save.
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // if gameboard is not null

            // leave for now
        }
    }
}
