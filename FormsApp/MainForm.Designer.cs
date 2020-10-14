namespace FormsApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnTest = new WinForm.UI.Controls.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxView1 = new WinForm.UI.Controls.GroupBoxView();
            this.button2 = new WinForm.UI.Controls.Button();
            this.button1 = new WinForm.UI.Controls.Button();
            this.treeView1 = new WinForm.UI.Controls.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.borderPanel1 = new WinForm.UI.Controls.BorderPanel();
            this.recyclerView1 = new WinForm.UI.Controls.RecyclerView();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new WinForm.UI.Controls.Button();
            this.groupBoxView1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Black;
            this.btnTest.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(12, 34);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 33);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "ADD DATA";
            this.btnTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 1);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // groupBoxView1
            // 
            this.groupBoxView1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.groupBoxView1.Controls.Add(this.button2);
            this.groupBoxView1.Controls.Add(this.button1);
            this.groupBoxView1.Location = new System.Drawing.Point(283, 34);
            this.groupBoxView1.Name = "groupBoxView1";
            this.groupBoxView1.Size = new System.Drawing.Size(266, 147);
            this.groupBoxView1.TabIndex = 3;
            this.groupBoxView1.Text = "支持自定义边框颜色的Group";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(148, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "DEFAULT";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(20, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "RED";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Border = "1";
            this.treeView1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(555, 34);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedNode = null;
            this.treeView1.Size = new System.Drawing.Size(233, 392);
            this.treeView1.TabIndex = 4;
            this.treeView1.Text = "treeView1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ImageFolderIcon.png");
            this.imageList1.Images.SetKeyName(1, "ImageFileIcon.png");
            // 
            // borderPanel1
            // 
            this.borderPanel1.Border = "1";
            this.borderPanel1.BorderColor = System.Drawing.Color.Lime;
            this.borderPanel1.Location = new System.Drawing.Point(283, 187);
            this.borderPanel1.Name = "borderPanel1";
            this.borderPanel1.Size = new System.Drawing.Size(266, 107);
            this.borderPanel1.TabIndex = 5;
            // 
            // recyclerView1
            // 
            this.recyclerView1.Adapter = null;
            this.recyclerView1.Border = "1";
            this.recyclerView1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.recyclerView1.Location = new System.Drawing.Point(12, 94);
            this.recyclerView1.Name = "recyclerView1";
            this.recyclerView1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.recyclerView1.Size = new System.Drawing.Size(203, 332);
            this.recyclerView1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "RecyclerView";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(283, 300);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 33);
            this.button3.TabIndex = 8;
            this.button3.Text = "TABLE";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recyclerView1);
            this.Controls.Add(this.borderPanel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBoxView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTest);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winform.UI Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxView1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WinForm.UI.Controls.Button btnTest;
        private System.Windows.Forms.Label label1;
        private WinForm.UI.Controls.GroupBoxView groupBoxView1;
        private WinForm.UI.Controls.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private WinForm.UI.Controls.Button button1;
        private WinForm.UI.Controls.Button button2;
        private WinForm.UI.Controls.BorderPanel borderPanel1;
        private WinForm.UI.Controls.RecyclerView recyclerView1;
        private System.Windows.Forms.Label label2;
        private WinForm.UI.Controls.Button button3;
    }
}

