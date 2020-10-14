using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinForm.UI.Controls;
using WinForm.UI.Forms;
using WinForm.UI.Test.Entity;

namespace WinForm.UI.Test
{
    public partial class TableForm : BaseForm
    {
        private SimpleObjectAdapter<TradeBean> adapter;
        //private SimpleArrayAdapter adapter;
        private SynchronizationContext m_Context;
        private static Random random;

        public TableForm()
        {
            InitializeComponent();
            m_Context = WindowsFormsSynchronizationContext.Current;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            adapter = new SimpleObjectAdapter<TradeBean>();
            adapter.MouseMoveBackColor = Color.FromArgb(40, 0, 0);
            adapter.SelectedBackColor = Color.FromArgb(51, 46, 40);


            fTable1.Adapter = adapter;
            random = new Random();
            new Thread(() => {
                LoadData();
            }).Start();
        }

        private void fButton1_Click(object sender, EventArgs e)
        {
            new Thread(() => {
                LoadData();
            }).Start();
        }

        private void LoadData()
        {
            List<TradeBean> list = new List<TradeBean>();
            for (int i = 0; i < 20; i++)
            {
                TradeBean bean = new TradeBean()
                {
                    Name = "大蒜",
                    Code = "DS00"+i,
                    UpdateTime = DateTime.Now,
                    FirstPrice= RandomNumber(),
                    Price = RandomNumber(),
                    Settlement = RandomNumber(),
                    Highest = RandomNumber(),
                    Minimum = RandomNumber(),
                    Newest = RandomNumber(),
                    Number = RandomNumber(),
                    WarehouseCount= RandomNumber()
                };
                list.Add(bean);
            }
            m_Context.Post(UpdateTable,list);

        }

        private void UpdateTable(object state)
        {
            List<TradeBean> list = state as List<TradeBean>;
            adapter.AddItems(list);
        }

        private static decimal RandomNumber()
        {
            return (Decimal)random.Next(100, 99999);
        }

        private void fTable1_ItemClick(object sender, Events.ItemClickEventArgs e)
        {
            TradeBean bean= e.ViewHolder.UserData as TradeBean;
            MessageBox.Show(bean.Name);
        }
    }
}
