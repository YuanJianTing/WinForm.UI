using FormsApp.Adapters;
using FormsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI;
using WinForm.UI.Controls;
using WinForm.UI.Forms;

namespace FormsApp
{
    public partial class MainForm : BaseForm
    {

        private ContactsAdapter contactsAdapter;
        private int ContactsCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTree();

            string CachePath = Path.Combine(Application.StartupPath, "Cache");
            if (!Directory.Exists(CachePath))
                Directory.CreateDirectory(CachePath);
            contactsAdapter = new ContactsAdapter(CachePath);
            recyclerView1.Adapter = contactsAdapter;

            LoadRecyclerData();
        }

        private void LoadRecyclerData()
        {
            List<ContactsViewModel> data = new List<ContactsViewModel>();
            //recyclerView1
            for (int i = 0; i < 3; i++)
            {
                ContactsCount++;

                ContactsViewModel viewModel = new ContactsViewModel();
                viewModel.NickName = "张三"+ ContactsCount;
                viewModel.Number = "18888888888";
                viewModel.Time = DateTime.Now;
                viewModel.HeadUrl = "https://tvax1.sinaimg.cn/crop.0.0.1080.1080.180/748889bbly8gg06svcpmaj20u00u0jvb.jpg?KID=imgbed,tva&Expires=1601020889&ssig=ceBbQItDM0";
                data.Add(viewModel);
            }
            contactsAdapter.AddItems(data);
        }

        private void LoadTree()
        {
            TreeNodeItem root = new TreeNodeItem();
            root.ImageIndex = 0;
            root.Text = "Tree";

            string[] parents = { "C#", "JAVA", "PYTHON", "C++", "C", "JAVASCRIPT" };

            string[] infos = { "01", "02", "03", "04", "05", "06" };

            List<TreeNodeItem> treeNodes = new List<TreeNodeItem>();
            foreach (var item in parents)
            {
                TreeNodeItem treeNodeItem = new TreeNodeItem();
                treeNodeItem.Text = item;
                treeNodeItem.ImageIndex = 0;
                foreach (var ch in infos)
                {
                    treeNodeItem.Nodes.Add(new TreeNodeItem() {Text=ch,ImageIndex=1 });
                }
                treeNodes.Add(treeNodeItem);
            }
            root.Open = true;
            root.Nodes.AddRange(treeNodes);

            treeView1.Nodes.Add(root);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxView1.BorderColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBoxView1.BorderColor = ColorStyles.LineColor;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            LoadRecyclerData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Show(this);
        }
    }
}
