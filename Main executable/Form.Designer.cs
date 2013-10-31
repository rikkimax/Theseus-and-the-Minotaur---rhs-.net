using System;

namespace TATM.ME
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.element = new System.Windows.Forms.Integration.ElementHost();
            this.gameConfigCtrl1 = new TATM.SGCB.GameConfigCtrl();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.gameBoardCtrl1 = new TATM.SGCB.GameBoardCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.element);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.elementHost1);
            this.splitContainer1.Size = new System.Drawing.Size(684, 390);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // element
            // 
            this.element.Dock = System.Windows.Forms.DockStyle.Fill;
            this.element.Location = new System.Drawing.Point(0, 0);
            this.element.Name = "element";
            this.element.Size = new System.Drawing.Size(155, 390);
            this.element.TabIndex = 2;
            this.element.TabStop = false;
            this.element.Text = "elementHost2";
            this.element.Child = this.gameConfigCtrl1;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(525, 390);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.TabStop = false;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.gameBoardCtrl1;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 390);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form";
            this.Text = "Theseus and the Minotaur - Right Hand Side";
            this.Load += new System.EventHandler(this.Form_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        [STAThreadAttribute]
        public static void Main()
        {
            new Form().ShowDialog();
        }

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private SGCB.GameBoardCtrl gameBoardCtrl1;
        private System.Windows.Forms.Integration.ElementHost element;
        private SGCB.GameConfigCtrl gameConfigCtrl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}