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

namespace TATM.SGCB
{
    /// <summary>
    /// Interaction logic for GameBoardCtrl.xaml
    /// </summary>
    public partial class GameBoardCtrl : UserControl
    {
        List<CellCtrl> cells;

        public GameBoardCtrl()
        {
            InitializeComponent();
        }

        // how many cells do we need?
        // how do we pass the data to construct them?

        private bool needUpdatedCells;

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (needUpdatedCells)
            {
                // foreach cell children
                // AddChild(ctrl); 

                needUpdatedCells = false;
            }

            base.OnRender(drawingContext);
        }
    }
}
