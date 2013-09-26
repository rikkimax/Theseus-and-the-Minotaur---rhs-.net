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

namespace TATM.sgcb
{
    /// <summary>
    /// Interaction logic for CellCtrl.xaml
    /// </summary>
    public partial class CellCtrl : UserControl
    {
        public CellCtrl(DisplayMode mode)
        {
            InitializeComponent();
            this.mode = mode;
            
        }

        public bool hasLeftWall { get; set; }
        public bool hasRightWall { get; set; }
        public bool hasDownWall { get; set; }
        public bool hasUpWall { get; set; }
        public bool isExit { get; set; }
        public EntityType withEntity { get; set; }
        private DisplayMode mode;

        protected override void OnRender(DrawingContext dc)
        {
            LeftWall.Background = new SolidColorBrush(hasLeftWall ? Colors.Black : Colors.Transparent);
            RightWall.Background = new SolidColorBrush(hasRightWall ? Colors.Black : Colors.Transparent);
            BottomWall.Background = new SolidColorBrush(hasDownWall ? Colors.Black : Colors.Transparent);
            TopWall.Background = new SolidColorBrush(hasUpWall ? Colors.Black : Colors.Transparent);

            if (isExit)
            {
                // show the exit image
                ImageSourceConverter c = new ImageSourceConverter();
                Exit.Source = (ImageSource)c.ConvertFrom(global::TATM.sgcb.Resources.exit);
            }
            else
            {
                // remove the exit image
                Exit.Source = null;
            }

            if (withEntity == EntityType.Minotaur)
            {
                ImageSourceConverter c = new ImageSourceConverter();
                Exit.Source = (ImageSource)c.ConvertFrom(global::TATM.sgcb.Resources.minotaur);
            }
            else if (withEntity == EntityType.Theseus)
            {
                ImageSourceConverter c = new ImageSourceConverter();
                Exit.Source = (ImageSource)c.ConvertFrom(global::TATM.sgcb.Resources.theseus);
            }
            else
            {
                Exit.Source = null;
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            if (mode == DisplayMode.Design)
            {
                // All ya design code here.
                // i.e. modify the walls
                // if (e.GetPosition().X <= ...
            }
        }
    }
}
