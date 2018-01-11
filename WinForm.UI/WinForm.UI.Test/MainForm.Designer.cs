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
            this.fButton1 = new WinForm.UI.Controls.FButton();
            this.fButton2 = new WinForm.UI.Controls.FButton();
            this.fTextBox1 = new WinForm.UI.Controls.FTextBox();
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
            this.fTextBox1.Location = new System.Drawing.Point(291, 71);
            this.fTextBox1.Name = "fTextBox1";
            this.fTextBox1.Size = new System.Drawing.Size(178, 26);
            this.fTextBox1.TabIndex = 2;
            this.fTextBox1.WatermarkText = "请输入手机号";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 513);
            this.Controls.Add(this.fTextBox1);
            this.Controls.Add(this.fButton2);
            this.Controls.Add(this.fButton1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FButton fButton1;
        private Controls.FButton fButton2;
        private Controls.FTextBox fTextBox1;
    }
}

