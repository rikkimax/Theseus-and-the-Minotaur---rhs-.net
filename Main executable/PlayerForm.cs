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
