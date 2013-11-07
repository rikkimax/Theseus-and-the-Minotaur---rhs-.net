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
    /// Interaction logic for PlayerCtrl.xaml
    /// </summary>
    public partial class PlayerCtrl : UserControl
    {
       public delegate void RunPlayFormDelegate();
       public event RunPlayFormDelegate RunPlayForm;

        public PlayerCtrl()
        {
            InitializeComponent();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            RunPlayForm();
        }
    }
}
