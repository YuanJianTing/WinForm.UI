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
            WinForm.UI.Controls.TableColumn tableColumn1 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn2 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn3 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn4 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn5 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn6 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn7 = new WinForm.UI.Controls.TableColumn();
            WinForm.UI.Controls.TableColumn tableColumn8 = new WinForm.UI.Controls.TableColumn();
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
            this.table1.Location = new System.Drawing.Point(12, 56);
            this.table1.MouseMoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.table1.Name = "table1";
            this.table1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.table1.SelectionIndex = -1;
            this.table1.Size = new System.Drawing.Size(794, 449);
            this.table1.TabIndex = 0;
            tableColumn1.BindingData = "Name";
            tableColumn1.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn1.Desc = false;
            tableColumn1.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn1.ForeColor = System.Drawing.Color.White;
            tableColumn1.Format = null;
            tableColumn1.Text = "名 称";
            tableColumn1.Weight = 12.5F;
            tableColumn1.Width = 0;
            tableColumn2.BindingData = "Code";
            tableColumn2.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn2.Desc = false;
            tableColumn2.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn2.ForeColor = System.Drawing.Color.Lime;
            tableColumn2.Format = null;
            tableColumn2.Text = "交易码";
            tableColumn2.Weight = 12.5F;
            tableColumn2.Width = 0;
            tableColumn3.BindingData = "UpdateTime";
            tableColumn3.DataType = WinForm.UI.Controls.Emuns.DataType.DateTime;
            tableColumn3.Desc = false;
            tableColumn3.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn3.ForeColor = System.Drawing.Color.White;
            tableColumn3.Format = "HH:mm:ss";
            tableColumn3.SortColumn = true;
            tableColumn3.Text = "更新时间";
            tableColumn3.Weight = 12.5F;
            tableColumn3.Width = 0;
            tableColumn4.BindingData = "FirstPrice";
            tableColumn4.DataType = WinForm.UI.Controls.Emuns.DataType.Decimal;
            tableColumn4.Desc = false;
            tableColumn4.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn4.ForeColor = System.Drawing.Color.White;
            tableColumn4.Format = "#0.00";
            tableColumn4.SortColumn = true;
            tableColumn4.Text = "收盘";
            tableColumn4.Weight = 12.5F;
            tableColumn4.Width = 0;
            tableColumn5.BindingData = "Price";
            tableColumn5.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn5.Desc = false;
            tableColumn5.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn5.ForeColor = System.Drawing.Color.White;
            tableColumn5.Format = null;
            tableColumn5.Text = "开盘";
            tableColumn5.Weight = 12.5F;
            tableColumn5.Width = 0;
            tableColumn6.BindingData = "Settlement";
            tableColumn6.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn6.Desc = false;
            tableColumn6.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn6.ForeColor = System.Drawing.Color.White;
            tableColumn6.Format = null;
            tableColumn6.Text = "前结";
            tableColumn6.Weight = 12.5F;
            tableColumn6.Width = 0;
            tableColumn7.BindingData = "Highest";
            tableColumn7.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn7.Desc = false;
            tableColumn7.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn7.ForeColor = System.Drawing.Color.Red;
            tableColumn7.Format = null;
            tableColumn7.Text = "最高";
            tableColumn7.Weight = 12.5F;
            tableColumn7.Width = 0;
            tableColumn8.BindingData = "Minimum";
            tableColumn8.DataType = WinForm.UI.Controls.Emuns.DataType.String;
            tableColumn8.Desc = false;
            tableColumn8.Font = new System.Drawing.Font("微软雅黑", 9F);
            tableColumn8.ForeColor = System.Drawing.Color.White;
            tableColumn8.Format = null;
            tableColumn8.Text = "最低";
            tableColumn8.Weight = 12.5F;
            tableColumn8.Width = 0;
            this.table1.TableColumns.Add(tableColumn1);
            this.table1.TableColumns.Add(tableColumn2);
            this.table1.TableColumns.Add(tableColumn3);
            this.table1.TableColumns.Add(tableColumn4);
            this.table1.TableColumns.Add(tableColumn5);
            this.table1.TableColumns.Add(tableColumn6);
            this.table1.TableColumns.Add(tableColumn7);
            this.table1.TableColumns.Add(tableColumn8);
            this.table1.ColumnDragChanged += new System.EventHandler(this.table1_ColumnDragChanged);
            this.table1.SortClick += new System.EventHandler<WinForm.UI.Controls.TableColumnSortEventArgs>(this.table1_SortClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(457, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 28);
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