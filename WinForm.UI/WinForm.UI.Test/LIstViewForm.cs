using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinForm.UI.Forms;
using WinForm.UI.Test.Entity;

namespace WinForm.UI.Test
{
    public partial class ListViewForm : BaseForm
    {
        private SynchronizationContext m_Context;
        private ListViewAdapter adapter;

        public ListViewForm()
        {
            InitializeComponent();
            m_Context = WindowsFormsSynchronizationContext.Current;
        }

        private void LIstViewForm_Load(object sender, EventArgs e)
        {
            adapter = new ListViewAdapter();
            fListView1.Adapter = adapter;

            new Thread(() => {
                LoadData();
            }).Start();
        }

        private void LoadData()
        {
            List<Contart> list = new List<Contart>();
            for (int i = 0; i < 30; i++)
            {
                Contart data = new Contart();
                data.HeadUrl = "";
                data.IsLastMessage = true;
                data.LastMessage = "这个是第" + i + "条。";
                data.LastMessageTime = DateTime.Now;
                data.NickName = "刘哈哈" + i;
                list.Add(data);
            }
            m_Context.Post(UpdateListView, list);
        }

        private void UpdateListView(object state)
        {
            List<Contart> list = state as List<Contart>;
            adapter.AddItems(list);
        }
    }
}
