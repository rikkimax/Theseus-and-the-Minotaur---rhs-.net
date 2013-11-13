using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TATM.LevelDesigner
{
    public partial class ViewDesigner : Form, IView
    {
        Controller controller;

        private int rows, cols;
        private int cellSize;
        private int xOffset, yOffset;
        Graphics graphic = null;
        private Image image;

        private int width { get { return (int)(this.pbxMap.Width * .9); } }
        private int height { get { return (int)(this.pbxMap.Height * .9); } }

        private int penWidth = 3;
        private Point highlightedCell;
        //private Point[] highlightedWall = null;
        private int highlightedWall = 0;
        private bool isMapDrawn = false;
        private bool allowedDraw = false;

        public ViewDesigner()
        {
            InitializeComponent();

            this.controller = new Controller(this);
            this.enableButtons();
        }

        public void show()
        {
            this.Show();
        }

        private void enableButtons()
        {
            if (this.cbxRows.Value >= 3 && this.cbxCols.Value >= 3) this.btnDrawMap.Enabled = true;
            else this.btnDrawMap.Enabled = false;
        }

        private void btnDrawMap_Click(object sender, EventArgs e)
        {
            this.allowedDraw = true;

            this.setMapDimensions();
            this.getSelectedImage();
            
            this.controller.createMap((int)this.cbxCols.Value, (int)this.cbxRows.Value);

            //this.setup();
            this.draw();
        }

        public void draw()
        {
            this.pbxMap.Invalidate();
        }

        private void setMapDimensions()
        {
            this.cols = (int)this.cbxCols.Value;
            this.rows = (int)this.cbxRows.Value;
        }

        private void cbxChange(object sender, EventArgs e)
        {
            this.enableButtons();
        }

        private void pbxMap_Paint(object sender, PaintEventArgs e)
        {
            if (this.allowedDraw)
            {
                this.graphic = e.Graphics;

                this.calculateCellSize();
                this.calculateOffsets();

                this.controller.draw();
            }
        }

        private void calculateCellSize()
        {
            //this.cellSize = Math.Max(this.pbxMap.Width, this.pbxMap.Height) / Math.Max(this.rows, this.cols);
            this.cellSize = (int)Math.Min((this.pbxMap.Width *.9 / this.cols), (this.pbxMap.Height * .9 / this.rows));
            //this.cellSize = (int)Math.Min((this.width / this.cols), (this.height / this.rows));
        }

        private void calculateOffsets()
        {
            this.xOffset = ((this.pbxMap.Width - (this.cellSize * this.cols)) / 2);
            this.yOffset = ((this.pbxMap.Height - (this.cellSize * this.rows)) / 2);
        }

        public void drawCell(int x, int y, bool[] walls)
        {
            this.penWidth = 3;

            float size = (float)this.cellSize;
            float startX = (x * this.cellSize) + this.xOffset;
            float startY = (y * this.cellSize) + this.yOffset;

            this.graphic.DrawImage(this.image, startX + (float)this.penWidth / 2, startY + (float)this.penWidth / 2, size, size);

            /*Point topLeft = new Point((int)startX + this.penWidth, (int)startY + (this.penWidth / 2));
            Point topRight = new Point((int)startX + this.cellSize - (this.penWidth / 2), (int)startY + (this.penWidth / 2));
            Point bottomRight = new Point((int)startX + this.cellSize - (this.penWidth / 2), (int)startY + this.cellSize - (this.penWidth / 2));
            Point bottomLeft = new Point((int)startX + (this.penWidth / 2), (int)startY + this.cellSize - (this.penWidth / 2));*/


            Point topLeft = new Point((int)startX, (int)startY);
            Point topRight = new Point((int)startX + this.cellSize, (int)startY);
            Point bottomRight = new Point((int)startX + this.cellSize, (int)startY + this.cellSize);
            Point bottomLeft = new Point((int)startX, (int)startY + this.cellSize);
            Size pen = new Size(this.penWidth / 2, this.penWidth / 2);

            Pen black = new Pen(Brushes.Black, this.penWidth);
            Pen blue = new Pen(Brushes.LightBlue, this.penWidth);

            //this.graphic.DrawLine(blue, Point.Subtract(topLeft, pen), Point.Subtract(topRight, pen));

            if(walls[0]) this.graphic.DrawLine(black, topLeft, topRight);
            else this.graphic.DrawLine(blue, Point.Subtract(topLeft, pen), Point.Subtract(topRight, pen));

            if (walls[1]) this.graphic.DrawLine(black, topRight, bottomRight);
            else this.graphic.DrawLine(blue, Point.Subtract(topRight, pen), Point.Subtract(bottomRight, pen));

            if (walls[2]) this.graphic.DrawLine(black, bottomRight, bottomLeft);
            if (walls[3]) this.graphic.DrawLine(black, bottomLeft, topLeft);

        }

        public void drawMap()
        {
            this.isMapDrawn = true;
        }

        private void getSelectedImage()
        {
            foreach (Control ctrl in this.panelCellImages.Controls)
            {
                if (ctrl.GetType() == typeof(RadioButton))
                {
                    RadioButton btn = (RadioButton)ctrl;
                    if (btn.Checked)
                    {
                        this.image = btn.Image;
                        break;
                    }
                }
            }
        }

        public void drawCellBorder(uint x, uint y, int border)//border = 1 is right, border = 2 is down
        {
            int endX, endY;
            int startX = endX = this.xOffset + (this.cellSize * (int)x) - this.penWidth / 2;
            int startY = endY = this.yOffset + (this.cellSize * (int)y) - this.penWidth / 2;

            switch (border)
            {
                case 1:
                    startX = endX = startX + this.cellSize;
                    endY += this.cellSize;
                    break;

                case 2:
                    startY = endY = startY + this.cellSize;
                    endX += this.cellSize;
                    break;
            }

            this.graphic.DrawLine(new Pen(Brushes.Black, this.penWidth), new Point(startX, startY), new Point(endX, endY)); 
        }

        private void pbxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMapDrawn)
            {
                int x = e.X - this.xOffset;
                int y = e.Y - this.yOffset;

                if (x > 0 && y > 0)
                {
                    this.highlightedCell = this.calculateHighlightedCell(x, y);
                    this.calculateHighlightedWall(x, y);

                    this.draw();
                }
            }
        }

        private bool calculateHighlightedWall(int x, int y)
        {
            this.highlightedWall = 0;

            int offset = 10;

            //if (y <= this.highlightedCell.Y * this.cellSize + this.yOffset + offset) this.highlightedWall = 1;
            if (this.controller.isAllowedWall(this.highlightedCell.X, this.highlightedCell.Y, 2) && x >= (this.highlightedCell.X + 1) * this.cellSize - this.xOffset - offset) this.highlightedWall = 2;
            else if (this.controller.isAllowedWall(this.highlightedCell.X, this.highlightedCell.Y, 3) && y >= (this.highlightedCell.Y + 1) * this.cellSize - this.yOffset - offset) this.highlightedWall = 3;

            //if (x <= this.highlightedCell.X * this.cellSize + this.xOffset + offset) this.highlightedWall = 4;


            return (this.highlightedWall != 0);
        }

        private Point calculateHighlightedCell(int x, int y)
        {
            x /= this.cellSize;
            y /= this.cellSize;

            return new Point(x, y);
        }

        public void drawHighlightedCell()
        {
            /*if (this.highlightedWall == 0)*/
            if (this.highlightedCell != Point.Empty) this.graphic.FillRectangle(new SolidBrush(Color.FromArgb(80, 77, 255, 204)), this.highlightedCell.X * this.cellSize + this.xOffset, this.highlightedCell.Y * this.cellSize + this.yOffset, this.cellSize, this.cellSize);
        }

        public void drawHighlightedWall()
        {
            if (this.highlightedWall != 0)
            {
                //Point topLeft = new Point(this.highlightedCell.X * this.cellSize + this.xOffset - this.penWidth / 2, this.highlightedCell.Y * this.cellSize + this.yOffset);
                Point topRight = new Point((this.highlightedCell.X + 1) * this.cellSize + this.xOffset - this.penWidth / 2, this.highlightedCell.Y * this.cellSize + this.yOffset);
                Point bottomRight = new Point((this.highlightedCell.X + 1) * this.cellSize + this.xOffset - this.penWidth / 2, (this.highlightedCell.Y + 1) * this.cellSize + this.yOffset - this.penWidth / 2);
                Point bottomLeft =new Point(this.highlightedCell.X * this.cellSize + this.xOffset - this.penWidth / 2, (this.highlightedCell.Y + 1) * this.cellSize + this.yOffset - this.penWidth / 2);

                switch (this.highlightedWall)
                {
                    /*case 1:
                        this.graphic.DrawLine(new Pen(Brushes.Red, this.penWidth), topLeft, topRight);
                        break;*/

                    case 2:
                        this.graphic.DrawLine(new Pen(Brushes.Red, this.penWidth), topRight, bottomRight);
                        break;

                    case 3:
                        this.graphic.DrawLine(new Pen(Brushes.Red, this.penWidth), bottomRight, bottomLeft);
                        break;

                    /*case 4:
                        this.graphic.DrawLine(new Pen(Brushes.Red, this.penWidth), topLeft, bottomLeft);
                        break;*/
                }
            }
        }

        public void drawEntity(int entity, int x, int y)// entity: 1 = theseus, 2 = mino, 3 = exit
        {
            Image image = null;
            switch (entity)
            {
                case 1:
                    image = Properties.Resources.theseus;
                    break;
                case 2:
                    image = Properties.Resources.minotaur;
                    break;
                case 3:
                    image = Properties.Resources.exit;
                    break;
            }

            this.graphic.DrawImage(image, x * this.cellSize + this.xOffset, y * this.cellSize + this.yOffset,this.cellSize, this.cellSize);
        }

        private void pbxMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.highlightedWall != 0) this.controller.setWall(this.highlightedCell.X, this.highlightedCell.Y, this.highlightedWall);
            else
            {
                if (e.Button == MouseButtons.Left) this.controller.removeCell(this.highlightedCell.X, this.highlightedCell.Y);
                else if (e.Button == MouseButtons.Right) this.controller.addCell(this.highlightedCell.X, this.highlightedCell.Y);
            }
        }

        private void entityMouseDown(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl != null)
            {
                this.pbxMap.AllowDrop = true;
                ctrl.DoDragDrop(ctrl.Name, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void pbxMap_DragDrop(object sender, DragEventArgs e)
        {
            foreach (PictureBox pbx in this.panelControls.Controls)
            {
                if (pbx.Name == e.Data.GetData(DataFormats.Text).ToString())
                {
                    Point location = this.pbxMap.PointToClient(new Point(e.X, e.Y));
                    Point cell = this.calculateHighlightedCell(location.X - this.xOffset, location.Y - this.yOffset);
                    this.controller.setEntity(pbx.Tag.ToString(), cell.X, cell.Y);
                }
            }
        }

        private void pbxMap_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
