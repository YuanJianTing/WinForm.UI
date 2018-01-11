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
            this.SuspendLayout();
            // 
            // fListView1
            // 
            this.fListView1.Adapter = null;
            this.fListView1.BackColor = System.Drawing.Color.Transparent;
            this.fListView1.Location = new System.Drawing.Point(21, 43);
            this.fListView1.Name = "fListView1";
            this.fListView1.Size = new System.Drawing.Size(399, 547);
            this.fListView1.TabIndex = 0;
            // 
            // ListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinForm.UI.Test.Properties.Resources.Crystal_Liu2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 627);
            this.Controls.Add(this.fListView1);
            this.MaximizeBox = false;
            this.Name = "ListViewForm";
            this.Text = "LIstViewForm";
            this.TitleBackColor = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.LIstViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FListView fListView1;
    }
}