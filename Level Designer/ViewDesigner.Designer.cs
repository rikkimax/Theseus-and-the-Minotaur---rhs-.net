namespace TATM.LevelDesigner
{
    partial class ViewDesigner
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
            System.Windows.Forms.Label lblWarning;
            System.Windows.Forms.Label lblRows;
            System.Windows.Forms.Label lblCols;
            System.Windows.Forms.Label lblTitle;
            this.panelControls = new System.Windows.Forms.Panel();
            this.pbxTheseus = new System.Windows.Forms.PictureBox();
            this.pbxExit = new System.Windows.Forms.PictureBox();
            this.pbxMinotaur = new System.Windows.Forms.PictureBox();
            this.cbxCols = new System.Windows.Forms.NumericUpDown();
            this.btnDrawMap = new System.Windows.Forms.Button();
            this.cbxRows = new System.Windows.Forms.NumericUpDown();
            this.panelForm = new System.Windows.Forms.TableLayoutPanel();
            this.panelCellImages = new System.Windows.Forms.Panel();
            this.rbtnDiamond = new System.Windows.Forms.RadioButton();
            this.rbtnBrick = new System.Windows.Forms.RadioButton();
            this.rbtnClay = new System.Windows.Forms.RadioButton();
            this.rbtnWood = new System.Windows.Forms.RadioButton();
            this.panelMap = new System.Windows.Forms.Panel();
            this.pbxMap = new System.Windows.Forms.PictureBox();
            lblWarning = new System.Windows.Forms.Label();
            lblRows = new System.Windows.Forms.Label();
            lblCols = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTheseus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMinotaur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRows)).BeginInit();
            this.panelForm.SuspendLayout();
            this.panelCellImages.SuspendLayout();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Location = new System.Drawing.Point(3, 0);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new System.Drawing.Size(0, 13);
            lblWarning.TabIndex = 0;
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.BackColor = System.Drawing.Color.Transparent;
            lblRows.Font = new System.Drawing.Font("Papyrus", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRows.Location = new System.Drawing.Point(18, 81);
            lblRows.Name = "lblRows";
            lblRows.Size = new System.Drawing.Size(83, 42);
            lblRows.TabIndex = 0;
            lblRows.Text = "Rows";
            lblRows.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCols
            // 
            lblCols.AutoSize = true;
            lblCols.BackColor = System.Drawing.Color.Transparent;
            lblCols.Font = new System.Drawing.Font("Papyrus", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblCols.Location = new System.Drawing.Point(21, 137);
            lblCols.Name = "lblCols";
            lblCols.Size = new System.Drawing.Size(124, 42);
            lblCols.TabIndex = 2;
            lblCols.Text = "Columns";
            lblCols.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Papyrus", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Location = new System.Drawing.Point(-1, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(270, 58);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Design a Map";
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.Transparent;
            this.panelControls.BackgroundImage = global::TATM.LevelDesigner.Properties.Resources.images__6_;
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Controls.Add(this.pbxTheseus);
            this.panelControls.Controls.Add(this.pbxExit);
            this.panelControls.Controls.Add(this.pbxMinotaur);
            this.panelControls.Controls.Add(this.cbxCols);
            this.panelControls.Controls.Add(this.btnDrawMap);
            this.panelControls.Controls.Add(this.cbxRows);
            this.panelControls.Controls.Add(lblRows);
            this.panelControls.Controls.Add(lblCols);
            this.panelControls.Controls.Add(lblTitle);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(20, 15);
            this.panelControls.Margin = new System.Windows.Forms.Padding(20, 15, 15, 15);
            this.panelControls.Name = "panelControls";
            this.panelControls.Padding = new System.Windows.Forms.Padding(10);
            this.panelControls.Size = new System.Drawing.Size(265, 733);
            this.panelControls.TabIndex = 9;
            // 
            // pbxTheseus
            // 
            this.pbxTheseus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxTheseus.BackgroundImage = global::TATM.LevelDesigner.Properties.Resources.theseus;
            this.pbxTheseus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxTheseus.Location = new System.Drawing.Point(164, 618);
            this.pbxTheseus.Name = "pbxTheseus";
            this.pbxTheseus.Size = new System.Drawing.Size(100, 100);
            this.pbxTheseus.TabIndex = 1;
            this.pbxTheseus.TabStop = false;
            this.pbxTheseus.Tag = "theseus";
            this.pbxTheseus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entityMouseDown);
            // 
            // pbxExit
            // 
            this.pbxExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxExit.BackgroundImage = global::TATM.LevelDesigner.Properties.Resources.exit;
            this.pbxExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxExit.Location = new System.Drawing.Point(84, 618);
            this.pbxExit.Name = "pbxExit";
            this.pbxExit.Size = new System.Drawing.Size(100, 100);
            this.pbxExit.TabIndex = 2;
            this.pbxExit.TabStop = false;
            this.pbxExit.Tag = "exit";
            this.pbxExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entityMouseDown);
            // 
            // pbxMinotaur
            // 
            this.pbxMinotaur.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxMinotaur.BackgroundImage = global::TATM.LevelDesigner.Properties.Resources.minotaur;
            this.pbxMinotaur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxMinotaur.Location = new System.Drawing.Point(-1, 618);
            this.pbxMinotaur.Name = "pbxMinotaur";
            this.pbxMinotaur.Size = new System.Drawing.Size(100, 100);
            this.pbxMinotaur.TabIndex = 0;
            this.pbxMinotaur.TabStop = false;
            this.pbxMinotaur.Tag = "minotaur";
            this.pbxMinotaur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entityMouseDown);
            // 
            // cbxCols
            // 
            this.cbxCols.Font = new System.Drawing.Font("Papyrus", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCols.Location = new System.Drawing.Point(159, 119);
            this.cbxCols.Name = "cbxCols";
            this.cbxCols.Size = new System.Drawing.Size(62, 50);
            this.cbxCols.TabIndex = 3;
            this.cbxCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.cbxCols.ValueChanged += new System.EventHandler(this.cbxChange);
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDrawMap.AutoSize = true;
            this.btnDrawMap.Enabled = false;
            this.btnDrawMap.Font = new System.Drawing.Font("Papyrus", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawMap.Location = new System.Drawing.Point(9, 560);
            this.btnDrawMap.Name = "btnDrawMap";
            this.btnDrawMap.Size = new System.Drawing.Size(158, 52);
            this.btnDrawMap.TabIndex = 4;
            this.btnDrawMap.Text = "Draw Map";
            this.btnDrawMap.UseVisualStyleBackColor = true;
            this.btnDrawMap.Click += new System.EventHandler(this.btnDrawMap_Click);
            // 
            // cbxRows
            // 
            this.cbxRows.Font = new System.Drawing.Font("Papyrus", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRows.Location = new System.Drawing.Point(159, 63);
            this.cbxRows.Name = "cbxRows";
            this.cbxRows.Size = new System.Drawing.Size(62, 50);
            this.cbxRows.TabIndex = 1;
            this.cbxRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.cbxRows.ValueChanged += new System.EventHandler(this.cbxChange);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.Transparent;
            this.panelForm.ColumnCount = 3;
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelForm.Controls.Add(this.panelControls, 0, 0);
            this.panelForm.Controls.Add(this.panelCellImages, 2, 0);
            this.panelForm.Controls.Add(this.panelMap, 1, 0);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.RowCount = 1;
            this.panelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelForm.Size = new System.Drawing.Size(1284, 763);
            this.panelForm.TabIndex = 14;
            // 
            // panelCellImages
            // 
            this.panelCellImages.BackColor = System.Drawing.Color.Transparent;
            this.panelCellImages.BackgroundImage = global::TATM.LevelDesigner.Properties.Resources.images__6_;
            this.panelCellImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCellImages.Controls.Add(this.rbtnDiamond);
            this.panelCellImages.Controls.Add(this.rbtnBrick);
            this.panelCellImages.Controls.Add(this.rbtnClay);
            this.panelCellImages.Controls.Add(this.rbtnWood);
            this.panelCellImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCellImages.Location = new System.Drawing.Point(994, 15);
            this.panelCellImages.Margin = new System.Windows.Forms.Padding(0, 15, 20, 15);
            this.panelCellImages.Name = "panelCellImages";
            this.panelCellImages.Padding = new System.Windows.Forms.Padding(10);
            this.panelCellImages.Size = new System.Drawing.Size(273, 733);
            this.panelCellImages.TabIndex = 11;
            // 
            // rbtnDiamond
            // 
            this.rbtnDiamond.AutoSize = true;
            this.rbtnDiamond.Image = global::TATM.LevelDesigner.Properties.Resources.diamond;
            this.rbtnDiamond.Location = new System.Drawing.Point(41, 545);
            this.rbtnDiamond.MaximumSize = new System.Drawing.Size(130, 130);
            this.rbtnDiamond.Name = "rbtnDiamond";
            this.rbtnDiamond.Size = new System.Drawing.Size(130, 130);
            this.rbtnDiamond.TabIndex = 2;
            this.rbtnDiamond.Tag = "diamond";
            this.rbtnDiamond.UseVisualStyleBackColor = true;
            // 
            // rbtnBrick
            // 
            this.rbtnBrick.AutoSize = true;
            this.rbtnBrick.Image = global::TATM.LevelDesigner.Properties.Resources.brick;
            this.rbtnBrick.Location = new System.Drawing.Point(41, 373);
            this.rbtnBrick.MaximumSize = new System.Drawing.Size(130, 130);
            this.rbtnBrick.Name = "rbtnBrick";
            this.rbtnBrick.Size = new System.Drawing.Size(130, 130);
            this.rbtnBrick.TabIndex = 1;
            this.rbtnBrick.Tag = "brick";
            this.rbtnBrick.UseVisualStyleBackColor = true;
            // 
            // rbtnClay
            // 
            this.rbtnClay.AutoSize = true;
            this.rbtnClay.Checked = true;
            this.rbtnClay.Image = global::TATM.LevelDesigner.Properties.Resources.clay;
            this.rbtnClay.Location = new System.Drawing.Point(41, 29);
            this.rbtnClay.MaximumSize = new System.Drawing.Size(130, 130);
            this.rbtnClay.Name = "rbtnClay";
            this.rbtnClay.Size = new System.Drawing.Size(130, 130);
            this.rbtnClay.TabIndex = 3;
            this.rbtnClay.TabStop = true;
            this.rbtnClay.Tag = "clay";
            this.rbtnClay.UseVisualStyleBackColor = true;
            // 
            // rbtnWood
            // 
            this.rbtnWood.AutoSize = true;
            this.rbtnWood.Image = global::TATM.LevelDesigner.Properties.Resources.wood;
            this.rbtnWood.Location = new System.Drawing.Point(41, 201);
            this.rbtnWood.MaximumSize = new System.Drawing.Size(130, 130);
            this.rbtnWood.Name = "rbtnWood";
            this.rbtnWood.Size = new System.Drawing.Size(130, 130);
            this.rbtnWood.TabIndex = 0;
            this.rbtnWood.Tag = "wood";
            this.rbtnWood.UseVisualStyleBackColor = true;
            // 
            // panelMap
            // 
            this.panelMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMap.BackColor = System.Drawing.Color.Transparent;
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMap.Controls.Add(lblWarning);
            this.panelMap.Controls.Add(this.pbxMap);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(300, 15);
            this.panelMap.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(679, 733);
            this.panelMap.TabIndex = 10;
            this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxMap_Paint);
            // 
            // pbxMap
            // 
            this.pbxMap.BackColor = System.Drawing.Color.Transparent;
            this.pbxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxMap.Location = new System.Drawing.Point(0, 0);
            this.pbxMap.Name = "pbxMap";
            this.pbxMap.Padding = new System.Windows.Forms.Padding(1);
            this.pbxMap.Size = new System.Drawing.Size(677, 731);
            this.pbxMap.TabIndex = 5;
            this.pbxMap.TabStop = false;
            this.pbxMap.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxMap_DragDrop);
            this.pbxMap.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbxMap_DragEnter);
            this.pbxMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxMap_Paint);
            this.pbxMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxMap_MouseClick);
            this.pbxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxMap_MouseMove);
            // 
            // ViewDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TATM.LevelDesigner.Properties.Resources.images__5_;
            this.ClientSize = new System.Drawing.Size(1284, 763);
            this.Controls.Add(this.panelForm);
            this.Name = "ViewDesigner";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTheseus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMinotaur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRows)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelCellImages.ResumeLayout(false);
            this.panelCellImages.PerformLayout();
            this.panelMap.ResumeLayout(false);
            this.panelMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnWood;
        private System.Windows.Forms.NumericUpDown cbxCols;
        private System.Windows.Forms.Button btnDrawMap;
        private System.Windows.Forms.NumericUpDown cbxRows;
        private System.Windows.Forms.RadioButton rbtnDiamond;
        private System.Windows.Forms.RadioButton rbtnBrick;
        private System.Windows.Forms.PictureBox pbxTheseus;
        private System.Windows.Forms.PictureBox pbxExit;
        private System.Windows.Forms.PictureBox pbxMinotaur;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.PictureBox pbxMap;
        private System.Windows.Forms.Panel panelCellImages;
        private System.Windows.Forms.RadioButton rbtnClay;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.TableLayoutPanel panelForm;
    }
}

