using FormsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Extension;
using WinForm.UI.Forms;

namespace FormsApp
{
    public partial class TableForm : BaseForm
    {
        private static Random random;

        private SynchronizationContext m_Context;

        public TableForm()
        {
            InitializeComponent();
            m_Context = WindowsFormsSynchronizationContext.Current;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            random = new Random();
            Task.Run(LoadData).ContinueWith(o => m_context.Post(UpdateUI, o.Result));
        }

        private void UpdateUI(object state)
        {
            List<TradeViewModel> list = state as List<TradeViewModel>;
            table1.DataSource = list;
        }

        private List<TradeViewModel> LoadData()
        {
            List<TradeViewModel> list = new List<TradeViewModel>();
            for (int i = 0; i < 20; i++)
            {
                TradeViewModel bean = new TradeViewModel()
                {
                    Name = "大蒜"+i,
                    Code = "DS00" + i,
                    UpdateTime = DateTime.Now,
                    FirstPrice = RandomNumber(),
                    Price = RandomNumber(),
                    Settlement = RandomNumber(),
                    Highest = RandomNumber(),
                    Minimum = RandomNumber(),
                    Newest = RandomNumber(),
                    Number = RandomNumber(),
                    WarehouseCount = RandomNumber()
                };
                list.Add(bean);
            }
            return list;
        }

        private static decimal RandomNumber()
        {
            return (Decimal)random.Next(100, 99999);
        }

        private void table1_SortClick(object sender, WinForm.UI.Controls.TableColumnSortEventArgs e)
        {
            MessageBox.Show(e.TableColumn.Text+"-排序事件-"+e.TableColumn.Desc);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Task.Run(LoadData).ContinueWith(o => m_context.Post(UpdateAddData, o.Result));
        }

        private void UpdateAddData(object state)
        {
            List<TradeViewModel> list = state as List<TradeViewModel>;
            table1.DataSource.AddRange( list);
            table1.NotifyDataSetChanged();
        }

        private void table1_ColumnDragChanged(object sender, EventArgs e)
        {
            MessageBox.Show("table1_ColumnDragChanged");
        }
    }
}
