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
            this.circlePictureBox1 = new WinForm.UI.Controls.CirclePictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.fTextBox2 = new WinForm.UI.Controls.FTextBox();
            this.fTextBox3 = new WinForm.UI.Controls.FTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // fButton1
            // 
            this.fButton1.BeginBackColor = System.Drawing.Color.Black;
            this.fButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton1.EndBackColor = System.Drawing.Color.Black;
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
            this.fButton2.BeginBackColor = System.Drawing.Color.Black;
            this.fButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton2.EndBackColor = System.Drawing.Color.Black;
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
            this.fButton3.BeginBackColor = System.Drawing.Color.Black;
            this.fButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton3.EndBackColor = System.Drawing.Color.Black;
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
            this.fButton4.BeginBackColor = System.Drawing.Color.Black;
            this.fButton4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton4.EndBackColor = System.Drawing.Color.Black;
            this.fButton4.ForeColor = System.Drawing.Color.White;
            this.fButton4.Location = new System.Drawing.Point(151, 129);
            this.fButton4.Name = "fButton4";
            this.fButton4.Size = new System.Drawing.Size(98, 36);
            this.fButton4.TabIndex = 4;
            this.fButton4.Text = "Toast";
            this.fButton4.Click += new System.EventHandler(this.fButton4_Click);
            // 
            // circlePictureBox1
            // 
            this.circlePictureBox1.Image = global::WinForm.UI.Test.Properties.Resources.default_head;
            this.circlePictureBox1.Location = new System.Drawing.Point(671, 41);
            this.circlePictureBox1.Name = "circlePictureBox1";
            this.circlePictureBox1.Size = new System.Drawing.Size(149, 149);
            this.circlePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.circlePictureBox1.TabIndex = 6;
            this.circlePictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
           
            // 
            // fTextBox2
            // 
            this.fTextBox2.Location = new System.Drawing.Point(488, 245);
            this.fTextBox2.Name = "fTextBox2";
            this.fTextBox2.Size = new System.Drawing.Size(178, 26);
            this.fTextBox2.TabIndex = 8;
            this.fTextBox2.WatermarkText = "请输入手机号";
           
            // 
            // fTextBox3
            // 
            this.fTextBox3.Location = new System.Drawing.Point(408, 334);
            this.fTextBox3.Name = "fTextBox3";
            this.fTextBox3.Size = new System.Drawing.Size(178, 26);
            this.fTextBox3.TabIndex = 10;
            this.fTextBox3.WatermarkText = "请输入手机号";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(832, 513);
            this.Controls.Add(this.fTextBox3);
            this.Controls.Add(this.fTextBox2);
            this.Controls.Add(this.circlePictureBox1);
            this.Controls.Add(this.fButton4);
            this.Controls.Add(this.fButton3);
            this.Controls.Add(this.fTextBox1);
            this.Controls.Add(this.fButton2);
            this.Controls.Add(this.fButton1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controls.FTextBox fTextBox2;
        private Controls.FTextBox fTextBox3;
    }
}

