namespace WinForm.UI.Test
{
    partial class ListViewForm
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
            this.fListView1 = new WinForm.UI.Controls.FListView();
            this.fButton1 = new WinForm.UI.Controls.FButton();
            this.fButton2 = new WinForm.UI.Controls.FButton();
            this.SuspendLayout();
            // 
            // fListView1
            // 
            this.fListView1.Adapter = null;
            this.fListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fListView1.BackColor = System.Drawing.Color.Transparent;
            this.fListView1.ItemDivider = 10;
            this.fListView1.Location = new System.Drawing.Point(12, 94);
            this.fListView1.MouseHolder = null;
            this.fListView1.Name = "fListView1";
            this.fListView1.SelectHolder = null;
            this.fListView1.Size = new System.Drawing.Size(355, 564);
            this.fListView1.TabIndex = 0;
            this.fListView1.ItemClick += new WinForm.UI.Controls.FListView.ItemClickHandler(this.fListView1_ItemClick);
            // 
            // fButton1
            // 
            this.fButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton1.ForeColor = System.Drawing.Color.White;
            this.fButton1.Location = new System.Drawing.Point(200, 43);
            this.fButton1.Name = "fButton1";
            this.fButton1.Size = new System.Drawing.Size(90, 28);
            this.fButton1.TabIndex = 1;
            this.fButton1.Text = "滚动到底部";
            this.fButton1.Click += new System.EventHandler(this.fButton1_Click);
            // 
            // fButton2
            // 
            this.fButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton2.ForeColor = System.Drawing.Color.White;
            this.fButton2.Location = new System.Drawing.Point(70, 43);
            this.fButton2.Name = "fButton2";
            this.fButton2.Size = new System.Drawing.Size(90, 28);
            this.fButton2.TabIndex = 2;
            this.fButton2.Text = "添加数据";
            this.fButton2.Click += new System.EventHandler(this.fButton2_Click);
            // 
            // ListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::WinForm.UI.Test.Properties.Resources.CrystalLiu4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 681);
            this.Controls.Add(this.fButton2);
            this.Controls.Add(this.fButton1);
            this.Controls.Add(this.fListView1);
            this.MaximizeBox = false;
            this.Name = "ListViewForm";
            this.Text = "QQ";
            this.TitleBackColor = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.LIstViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FListView fListView1;
        private Controls.FButton fButton1;
        private Controls.FButton fButton2;
    }
}