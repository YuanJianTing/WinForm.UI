namespace WinForm.UI.Test
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
            this.fTable1 = new WinForm.UI.Controls.FTable();
            this.tableColumn1 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn2 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn3 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn4 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn5 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn6 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn7 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn8 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn9 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn10 = new WinForm.UI.Controls.TableColumn();
            this.tableColumn11 = new WinForm.UI.Controls.TableColumn();
            this.fButton1 = new WinForm.UI.Controls.FButton();
            this.SuspendLayout();
            // 
            // fTable1
            // 
            this.fTable1.Adapter = null;
            this.fTable1.BackColor = System.Drawing.Color.Black;
            this.fTable1.CellBorderStyle = WinForm.UI.Controls.CellBorderStyle.FixedSingle;
            this.fTable1.ColumnHeaderColor = System.Drawing.Color.Black;
            this.fTable1.ColumnHeight = 30;
            this.fTable1.Columns.AddRange(new WinForm.UI.Controls.TableColumn[] {
            this.tableColumn1,
            this.tableColumn2,
            this.tableColumn3,
            this.tableColumn4,
            this.tableColumn5,
            this.tableColumn6,
            this.tableColumn7,
            this.tableColumn8,
            this.tableColumn9,
            this.tableColumn10,
            this.tableColumn11});
            this.fTable1.ForeColor = System.Drawing.Color.White;
            this.fTable1.HeaderHeight = 30;
            this.fTable1.Location = new System.Drawing.Point(12, 47);
            this.fTable1.Name = "fTable1";
            this.fTable1.Size = new System.Drawing.Size(732, 391);
            this.fTable1.TabIndex = 0;
            this.fTable1.ItemClick += new WinForm.UI.Controls.FTable.ItemClickHandler(this.fTable1_ItemClick);
            // 
            // tableColumn1
            // 
            this.tableColumn1.BindingData = "Name";
            this.tableColumn1.DisplayIndex = -1;
            this.tableColumn1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn1.ForeColor = System.Drawing.Color.Yellow;
            this.tableColumn1.Text = "名 称";
            this.tableColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn1.Visible = true;
            this.tableColumn1.Width = 80;
            // 
            // tableColumn2
            // 
            this.tableColumn2.BindingData = "Code";
            this.tableColumn2.DisplayIndex = -1;
            this.tableColumn2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn2.ForeColor = System.Drawing.Color.White;
            this.tableColumn2.Text = "交易码";
            this.tableColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn2.Visible = true;
            this.tableColumn2.Width = 80;
            // 
            // tableColumn3
            // 
            this.tableColumn3.BindingData = "UpdateTime";
            this.tableColumn3.DisplayIndex = -1;
            this.tableColumn3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn3.ForeColor = System.Drawing.Color.White;
            this.tableColumn3.Text = "更新时间";
            this.tableColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn3.Visible = true;
            this.tableColumn3.Width = 150;
            // 
            // tableColumn4
            // 
            this.tableColumn4.BindingData = "FirstPrice";
            this.tableColumn4.DisplayIndex = -1;
            this.tableColumn4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn4.ForeColor = System.Drawing.Color.White;
            this.tableColumn4.Text = "前收";
            this.tableColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn4.Visible = true;
            this.tableColumn4.Width = 80;
            // 
            // tableColumn5
            // 
            this.tableColumn5.BindingData = "Price";
            this.tableColumn5.DisplayIndex = -1;
            this.tableColumn5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn5.ForeColor = System.Drawing.Color.White;
            this.tableColumn5.Text = "开盘";
            this.tableColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn5.Visible = true;
            this.tableColumn5.Width = 80;
            // 
            // tableColumn6
            // 
            this.tableColumn6.BindingData = "Settlement";
            this.tableColumn6.DisplayIndex = -1;
            this.tableColumn6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn6.ForeColor = System.Drawing.Color.White;
            this.tableColumn6.Text = "前结";
            this.tableColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn6.Visible = true;
            this.tableColumn6.Width = 80;
            // 
            // tableColumn7
            // 
            this.tableColumn7.BindingData = "Highest";
            this.tableColumn7.DisplayIndex = -1;
            this.tableColumn7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn7.ForeColor = System.Drawing.Color.White;
            this.tableColumn7.Text = "最高";
            this.tableColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn7.Visible = true;
            this.tableColumn7.Width = 80;
            // 
            // tableColumn8
            // 
            this.tableColumn8.BindingData = "Minimum";
            this.tableColumn8.DisplayIndex = -1;
            this.tableColumn8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn8.ForeColor = System.Drawing.Color.White;
            this.tableColumn8.Text = "最低";
            this.tableColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn8.Visible = true;
            this.tableColumn8.Width = 80;
            // 
            // tableColumn9
            // 
            this.tableColumn9.BindingData = "Newest";
            this.tableColumn9.DisplayIndex = -1;
            this.tableColumn9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn9.ForeColor = System.Drawing.Color.White;
            this.tableColumn9.Text = "最新";
            this.tableColumn9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn9.Visible = true;
            this.tableColumn9.Width = 80;
            // 
            // tableColumn10
            // 
            this.tableColumn10.BindingData = "Number";
            this.tableColumn10.DisplayIndex = -1;
            this.tableColumn10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn10.ForeColor = System.Drawing.Color.White;
            this.tableColumn10.Text = "成交量";
            this.tableColumn10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn10.Visible = true;
            this.tableColumn10.Width = 80;
            // 
            // tableColumn11
            // 
            this.tableColumn11.BindingData = "WarehouseCount";
            this.tableColumn11.DisplayIndex = -1;
            this.tableColumn11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumn11.ForeColor = System.Drawing.Color.White;
            this.tableColumn11.Text = "持仓";
            this.tableColumn11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tableColumn11.Visible = true;
            this.tableColumn11.Width = 80;
            // 
            // fButton1
            // 
            this.fButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton1.ForeColor = System.Drawing.Color.White;
            this.fButton1.Location = new System.Drawing.Point(645, 464);
            this.fButton1.Name = "fButton1";
            this.fButton1.Size = new System.Drawing.Size(99, 30);
            this.fButton1.TabIndex = 1;
            this.fButton1.Text = "添加数据";
            this.fButton1.Click += new System.EventHandler(this.fButton1_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 534);
            this.Controls.Add(this.fButton1);
            this.Controls.Add(this.fTable1);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.Load += new System.EventHandler(this.TableForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FTable fTable1;
        private Controls.FButton fButton1;
        private Controls.TableColumn tableColumn1;
        private Controls.TableColumn tableColumn2;
        private Controls.TableColumn tableColumn3;
        private Controls.TableColumn tableColumn4;
        private Controls.TableColumn tableColumn5;
        private Controls.TableColumn tableColumn6;
        private Controls.TableColumn tableColumn7;
        private Controls.TableColumn tableColumn8;
        private Controls.TableColumn tableColumn9;
        private Controls.TableColumn tableColumn10;
        private Controls.TableColumn tableColumn11;
    }
}