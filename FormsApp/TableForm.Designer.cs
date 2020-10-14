namespace FormsApp
{
    partial class TableForm
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
            WinForm.UI.Controls.TableColumn tableColumn9 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn10 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn11 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn12 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn13 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn14 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn15 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn16 = new WinForm.UI.Controls.TableColumn();
            this.table1 = new WinForm.UI.Controls.Table();
            this.button1 = new WinForm.UI.Controls.Button();
            this.SuspendLayout();
            // 
            // table1
            // 
            this.table1.AllowUserToOrderColumns = true;
            this.table1.AllowUserToOrderRows = true;
            this.table1.AllowUserToResizeColumns = true;
            this.table1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table1.Border = "1";
            this.table1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.table1.DataSource = null;
            this.table1.ForeColor = System.Drawing.Color.White;
            this.table1.HeaderHeight = 40;
            this.table1.Location = new System.Drawing.Point(12, 56);
            this.table1.MouseMoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.table1.Name = "table1";
            this.table1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.table1.SelectionIndex = -1;
            this.table1.Size = new System.Drawing.Size(794, 449);
            this.table1.TabIndex = 0;
            tableColumn9.BindingData = "Name";
            tableColumn9.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn9.Desc = false;
            tableColumn9.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn9.ForeColor = System.Drawing.Color.White;
            tableColumn9.Format = null;
            tableColumn9.Text = "名 称";
            tableColumn9.Weight = 12.5F;
            tableColumn9.Width = 0;
            tableColumn10.BindingData = "Code";
            tableColumn10.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn10.Desc = false;
            tableColumn10.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn10.ForeColor = System.Drawing.Color.Lime;
            tableColumn10.Format = null;
            tableColumn10.Text = "交易码";
            tableColumn10.Weight = 12.5F;
            tableColumn10.Width = 0;
            tableColumn11.BindingData = "UpdateTime";
            tableColumn11.DataType = WinForm.UI.Controls.Emuns.DataType.DateTime;
            tableColumn11.Desc = false;
            tableColumn11.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn11.ForeColor = System.Drawing.Color.White;
            tableColumn11.Format = "HH:mm:ss";
            tableColumn11.SortColumn = true;
            tableColumn11.Text = "更新时间";
            tableColumn11.Weight = 12.5F;
            tableColumn11.Width = 0;
            tableColumn12.BindingData = "FirstPrice";
            tableColumn12.DataType = WinForm.UI.Controls.Emuns.DataType.Decimal;
            tableColumn12.Desc = false;
            tableColumn12.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn12.ForeColor = System.Drawing.Color.White;
            tableColumn12.Format = "#0.00";
            tableColumn12.SortColumn = true;
            tableColumn12.Text = "收盘";
            tableColumn12.Weight = 12.5F;
            tableColumn12.Width = 0;
            tableColumn13.BindingData = "Price";
            tableColumn13.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn13.Desc = false;
            tableColumn13.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn13.ForeColor = System.Drawing.Color.White;
            tableColumn13.Format = null;
            tableColumn13.Text = "开盘";
            tableColumn13.Weight = 12.5F;
            tableColumn13.Width = 0;
            tableColumn14.BindingData = "Settlement";
            tableColumn14.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn14.Desc = false;
            tableColumn14.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn14.ForeColor = System.Drawing.Color.White;
            tableColumn14.Format = null;
            tableColumn14.Text = "前结";
            tableColumn14.Weight = 12.5F;
            tableColumn14.Width = 0;
            tableColumn15.BindingData = "Highest";
            tableColumn15.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn15.Desc = false;
            tableColumn15.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn15.ForeColor = System.Drawing.Color.Red;
            tableColumn15.Format = null;
            tableColumn15.Text = "最高";
            tableColumn15.Weight = 12.5F;
            tableColumn15.Width = 0;
            tableColumn16.BindingData = "Minimum";
            tableColumn16.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn16.Desc = false;
            tableColumn16.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn16.ForeColor = System.Drawing.Color.White;
            tableColumn16.Format = null;
            tableColumn16.Text = "最低";
            tableColumn16.Weight = 12.5F;
            tableColumn16.Width = 0;
            this.table1.TableColumns.Add(tableColumn9);
            this.table1.TableColumns.Add(tableColumn10);
            this.table1.TableColumns.Add(tableColumn11);
            this.table1.TableColumns.Add(tableColumn12);
            this.table1.TableColumns.Add(tableColumn13);
            this.table1.TableColumns.Add(tableColumn14);
            this.table1.TableColumns.Add(tableColumn15);
            this.table1.TableColumns.Add(tableColumn16);
            this.table1.SortClick += new System.EventHandler<WinForm.UI.Controls.TableColumnSortEventArgs>(this.table1_SortClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(457, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Data";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 528);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.table1);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.Load += new System.EventHandler(this.TableForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WinForm.UI.Controls.Table table1;
        private WinForm.UI.Controls.Button button1;
    }
}