namespace WinForm.UI.Test
{
    partial class FragmentForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.verticalScroll1 = new WinForm.UI.Controls.VerticalScroll();
            this.userFragment1 = new WinForm.UI.Test.UserFragment();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(162, 196);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(277, 272);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // verticalScroll1
            // 
            this.verticalScroll1.BackColor = System.Drawing.Color.Transparent;
            this.verticalScroll1.IsMouseDown = false;
            this.verticalScroll1.IsMouseOnSlider = false;
            this.verticalScroll1.Location = new System.Drawing.Point(600, 0);
            this.verticalScroll1.Name = "verticalScroll1";
            this.verticalScroll1.Owner = null;
            this.verticalScroll1.Size = new System.Drawing.Size(10, 324);
            this.verticalScroll1.TabIndex = 1;
            this.verticalScroll1.Text = "verticalScroll1";
            this.verticalScroll1.TrackColor = System.Drawing.Color.DimGray;
            this.verticalScroll1.VirtualHeight = 0;
            // 
            // userFragment1
            // 
            this.userFragment1.Location = new System.Drawing.Point(12, 12);
            this.userFragment1.Name = "userFragment1";
            this.userFragment1.Size = new System.Drawing.Size(492, 317);
            this.userFragment1.TabIndex = 0;
            // 
            // FragmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 543);
            this.Controls.Add(this.verticalScroll1);
            this.Controls.Add(this.userFragment1);
            this.Name = "FragmentForm";
            this.Text = "FragmentForm";
            this.Load += new System.EventHandler(this.FragmentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private UserFragment userFragment1;
        private Controls.VerticalScroll verticalScroll1;
    }
}