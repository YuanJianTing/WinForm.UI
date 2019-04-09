using System.Drawing;

namespace WinForm.UI.Test
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fButton1 = new WinForm.UI.Controls.FButton();
            this.fButton2 = new WinForm.UI.Controls.FButton();
            this.fTextBox1 = new WinForm.UI.Controls.FTextBox();
            this.fButton3 = new WinForm.UI.Controls.FButton();
            this.fButton4 = new WinForm.UI.Controls.FButton();
            this.fButton5 = new WinForm.UI.Controls.FButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黏贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fButton6 = new WinForm.UI.Controls.FButton();
            this.circlePictureBox2 = new WinForm.UI.Controls.CirclePictureBox();
            this.circlePictureBox1 = new WinForm.UI.Controls.CirclePictureBox();
            this.newLoadingView1 = new WinForm.UI.Controls.LoadingView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fButton1
            // 
            this.fButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton1.ForeColor = System.Drawing.Color.White;
            this.fButton1.Location = new System.Drawing.Point(26, 61);
            this.fButton1.Name = "fButton1";
            this.fButton1.Size = new System.Drawing.Size(98, 36);
            this.fButton1.TabIndex = 0;
            this.fButton1.Text = "ListView";
            this.fButton1.Click += new System.EventHandler(this.fButton1_Click);
            // 
            // fButton2
            // 
            this.fButton2.BackColor = System.Drawing.Color.DimGray;
            this.fButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton2.ForeColor = System.Drawing.Color.White;
            this.fButton2.Location = new System.Drawing.Point(151, 61);
            this.fButton2.Name = "fButton2";
            this.fButton2.Size = new System.Drawing.Size(98, 36);
            this.fButton2.TabIndex = 1;
            this.fButton2.Text = "Table";
            this.fButton2.Click += new System.EventHandler(this.fButton2_Click);
            // 
            // fTextBox1
            // 
            this.fTextBox1.Location = new System.Drawing.Point(282, 71);
            this.fTextBox1.Name = "fTextBox1";
            this.fTextBox1.Size = new System.Drawing.Size(178, 26);
            this.fTextBox1.TabIndex = 2;
            this.fTextBox1.WatermarkText = "请输入手机号";
            // 
            // fButton3
            // 
            this.fButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton3.ForeColor = System.Drawing.Color.White;
            this.fButton3.Location = new System.Drawing.Point(26, 129);
            this.fButton3.Name = "fButton3";
            this.fButton3.Size = new System.Drawing.Size(98, 36);
            this.fButton3.TabIndex = 3;
            this.fButton3.Text = "Dialog";
            this.fButton3.Click += new System.EventHandler(this.fButton3_Click);
            // 
            // fButton4
            // 
            this.fButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fButton4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton4.ForeColor = System.Drawing.Color.White;
            this.fButton4.Location = new System.Drawing.Point(151, 129);
            this.fButton4.Name = "fButton4";
            this.fButton4.Size = new System.Drawing.Size(98, 36);
            this.fButton4.TabIndex = 4;
            this.fButton4.Text = "Toast";
            this.fButton4.Click += new System.EventHandler(this.fButton4_Click);
            // 
            // fButton5
            // 
            this.fButton5.BackColor = System.Drawing.Color.Black;
            this.fButton5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton5.ForeColor = System.Drawing.Color.White;
            this.fButton5.Location = new System.Drawing.Point(282, 129);
            this.fButton5.Name = "fButton5";
            this.fButton5.Size = new System.Drawing.Size(98, 36);
            this.fButton5.TabIndex = 11;
            this.fButton5.Text = "Subimt";
            this.fButton5.Click += new System.EventHandler(this.fButton5_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.黏贴ToolStripMenuItem,
            this.toolStripSeparator1,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 76);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 黏贴ToolStripMenuItem
            // 
            this.黏贴ToolStripMenuItem.Name = "黏贴ToolStripMenuItem";
            this.黏贴ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.黏贴ToolStripMenuItem.Text = "黏贴";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            // 
            // fButton6
            // 
            this.fButton6.BackColor = System.Drawing.Color.Black;
            this.fButton6.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton6.ForeColor = System.Drawing.Color.White;
            this.fButton6.Location = new System.Drawing.Point(190, 171);
            this.fButton6.Name = "fButton6";
            this.fButton6.Size = new System.Drawing.Size(98, 36);
            this.fButton6.TabIndex = 13;
            this.fButton6.Text = "开 始";
            this.fButton6.Click += new System.EventHandler(this.fButton6_Click);
            // 
            // circlePictureBox2
            // 
            this.circlePictureBox2.Image = global::WinForm.UI.Test.Properties.Resources.img_download;
            this.circlePictureBox2.IsSelected = false;
            this.circlePictureBox2.Location = new System.Drawing.Point(357, 184);
            this.circlePictureBox2.MouseMoveImage = global::WinForm.UI.Test.Properties.Resources.img_download_move;
            this.circlePictureBox2.Name = "circlePictureBox2";
            this.circlePictureBox2.SelectedImage = null;
            this.circlePictureBox2.Size = new System.Drawing.Size(23, 23);
            this.circlePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.circlePictureBox2.TabIndex = 15;
            this.circlePictureBox2.TabStop = false;
            // 
            // circlePictureBox1
            // 
            this.circlePictureBox1.Image = global::WinForm.UI.Test.Properties.Resources.default_head;
            this.circlePictureBox1.IsSelected = false;
            this.circlePictureBox1.Location = new System.Drawing.Point(568, 50);
            this.circlePictureBox1.MouseMoveImage = null;
            this.circlePictureBox1.Name = "circlePictureBox1";
            this.circlePictureBox1.Radius = 20;
            this.circlePictureBox1.SelectedImage = global::WinForm.UI.Test.Properties.Resources.main_light_bkg_top123;
            this.circlePictureBox1.Size = new System.Drawing.Size(149, 149);
            this.circlePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.circlePictureBox1.TabIndex = 6;
            this.circlePictureBox1.TabStop = false;
            this.circlePictureBox1.Click += new System.EventHandler(this.circlePictureBox1_Click);
            // 
            // newLoadingView1
            // 
            this.newLoadingView1.Enabled = false;
            this.newLoadingView1.Location = new System.Drawing.Point(435, 250);
            this.newLoadingView1.Name = "newLoadingView1";
            this.newLoadingView1.Size = new System.Drawing.Size(134, 134);
            this.newLoadingView1.TabIndex = 16;
            this.newLoadingView1.Text = "newLoadingView1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(832, 513);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.newLoadingView1);
            this.Controls.Add(this.circlePictureBox2);
            this.Controls.Add(this.fButton6);
            this.Controls.Add(this.fButton5);
            this.Controls.Add(this.circlePictureBox1);
            this.Controls.Add(this.fButton4);
            this.Controls.Add(this.fButton3);
            this.Controls.Add(this.fTextBox1);
            this.Controls.Add(this.fButton2);
            this.Controls.Add(this.fButton1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TitleHeight = 25;
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FButton fButton1;
        private Controls.FButton fButton2;
        private Controls.FTextBox fTextBox1;
        private Controls.FButton fButton3;
        private Controls.FButton fButton4;
        private Controls.CirclePictureBox circlePictureBox1;
        private Controls.FButton fButton5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 黏贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private Controls.FButton fButton6;
        private Controls.CirclePictureBox circlePictureBox2;
        private Controls.LoadingView newLoadingView1;
    }
}

