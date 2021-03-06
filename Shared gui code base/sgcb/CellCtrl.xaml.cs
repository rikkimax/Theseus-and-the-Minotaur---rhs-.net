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
    /// Interaction logic for CellCtrl.xaml
    /// </summary>
    public partial class CellCtrl : UserControl
    {
        public CellCtrl()
        {
            InitializeComponent();

            hasLeftWall = false;
            hasUpWall = false;
            hasRightWall = false;
            hasDownWall = false;

            isExit = false;
        }

        public bool hasLeftWall { get; set; }
        public bool hasRightWall { get; set; }
        public bool hasDownWall { get; set; }
        public bool hasUpWall { get; set; }
        public bool isExit { get; set; }
        public EntityType withEntity { get; set; }

        public Cell data { get; set; }
        public DisplayMode mode { get; set; }

        protected override void OnRender(DrawingContext dc)
        {
            if (data != null)
            {
                if (data.inAccessible)
                {
                    hasLeftWall = false;
                    hasUpWall = false;
                    hasRightWall = false;
                    hasDownWall = false;

                    isExit = false;
                }
                else
                {
                    //hasLeftWall = false;
                    //hasUpWall = false;
                    hasRightWall = data.border.right;
                    hasDownWall = data.border.down;
                    isExit = data.isExit;
                }

                LeftWall.Background = new SolidColorBrush(hasLeftWall ? Colors.Black : Colors.Transparent);
                RightWall.Background = new SolidColorBrush(hasRightWall ? Colors.Black : Colors.Transparent);
                BottomWall.Background = new SolidColorBrush(hasDownWall ? Colors.Black : Colors.Transparent);
                TopWall.Background = new SolidColorBrush(hasUpWall ? Colors.Black : Colors.Transparent);

                if (isExit)
                {
                    var hBitmap = global::TATM.SGCB.Properties.Resources.exit.GetHbitmap();
                    var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                    Exit.Source = result;
                }
                else
                {
                    // remove the exit image
                    Exit.Source = null;
                }

                if (withEntity == EntityType.Minotaur)
                {
                    var hBitmap = global::TATM.SGCB.Properties.Resources.minotaur.GetHbitmap();
                    var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                    Entity.Source = result;
                }
                else if (withEntity == EntityType.Theseus)
                {
                    var hBitmap = global::TATM.SGCB.Properties.Resources.theseus.GetHbitmap();
                    var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                    Entity.Source = result;
                }
                else
                {
                    Entity.Source = null;
                }
            }
            base.OnRender(dc);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (mode == DisplayMode.Design)
            {
                // All ya design code here.
                // i.e. modify the walls
                // if (e.GetPosition().X <= ...
                // remember do it to data model not to internal state!
            }
            base.OnMouseUp(e);
        }
    }
}
