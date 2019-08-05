using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Controls;
using WinForm.UI.Utils;
using static WinForm.UI.Utils.Win32;

namespace WinForm.UI.Fragments
{
    public class Fragment : UserControl
    {
        private VScroll vScroll;
        public Panel innerPanel;
        public Panel GetPanel
        {
            get { return innerPanel; }
        }

        private int VirtualHeight = 0;

        public new ControlCollection Controls { get => innerPanel.Controls; }

        public Fragment()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Selectable, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();

            InitializeComponent();
            this.innerPanel.Size = new System.Drawing.Size(this.Width, this.Height);

            vScroll = new VScroll(this);
            vScroll.OnScrollEvent += VScroll_OnScrollEvent;

        }

        private void VScroll_OnScrollEvent(object sender, ScrollEventArgs e)
        {
            Console.WriteLine(e.NewValue);

            innerPanel.AutoScrollPosition = new System.Drawing.Point(0, e.NewValue);
            Application.DoEvents();

        }

        private void GetVirtualHeight()
        {
            VirtualHeight = innerPanel.VerticalScroll.Maximum;
            Console.WriteLine(VirtualHeight);
            //VirtualHeight = 0;
            //foreach (Control item in innerPanel.Controls)
            //{
            //    VirtualHeight += item.Bottom;
            //}
            //VerticalScroll.Maximum = VirtualHeight;
            //this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            vScroll.VirtualHeight = VirtualHeight;
            if (vScroll.Visible)
                vScroll.ReDrawScroll(e.Graphics);
            base.OnPaint(e);
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            innerPanel.Size = new System.Drawing.Size(this.Width + 20, this.Height + 20);
        }

        private void InitializeComponent()
        {
            this.innerPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // innerPanel
            // 
            this.innerPanel.Location = new System.Drawing.Point(0, 0);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Size = new System.Drawing.Size(258, 214);
            this.innerPanel.TabIndex = 0;
            innerPanel.AutoScroll = true;
            innerPanel.ControlAdded += InnerPanel_ControlAdded;
            innerPanel.ControlRemoved += InnerPanel_ControlRemoved;
            innerPanel.BackColor = Color.White;

            // 
            // Fragment
            // 
            base.Controls.Add(this.innerPanel);
            this.Name = "Fragment";
            this.Size = new System.Drawing.Size(258, 214);
            this.ResumeLayout(false);

        }

        private void InnerPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            GetVirtualHeight();
        }

        private void InnerPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            GetVirtualHeight();
        }
        
    }
}
