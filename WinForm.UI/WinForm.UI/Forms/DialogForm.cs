using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Controls;

namespace WinForm.UI.Forms
{
    public enum MessageFormIcon
    {
        /// <summary>
        /// 无图标
        /// </summary>
        None = 0,
        /// <summary>
        /// 显示一张 带有 OK 字样的图片
        /// </summary>
        OK = 1,
        /// <summary>
        /// 显示一张 带有 X 字样的图片
        /// </summary>
        Error = 2,
        /// <summary>
        /// 显示一张 带有 ！ 字样的图片
        /// </summary>
        Exclamation = 3,
        /// <summary>
        /// 显示一张 带有 ？ 字样的图片
        /// </summary>
        Doubt = 4
    }
    public enum MessageFormButtons
    {
        YesNo = 0,
        OK = 1
    }

    public partial class DialogForm : BaseForm
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        public static DialogResult Show(string message, string title = "提示", MessageFormIcon icon = MessageFormIcon.Doubt, MessageFormButtons button = MessageFormButtons.YesNo)
        {
            DialogForm dialg = new DialogForm();
            dialg.Text = title;
            dialg.SetText(message);
            dialg.SetButton(button);

            return dialg.ShowDialog();
        }

        public static DialogResult Show(Form form, string message, string title = "提示", MessageFormIcon icon = MessageFormIcon.Doubt, MessageFormButtons button = MessageFormButtons.YesNo)
        {
            DialogForm dialg = new DialogForm();
            dialg.StartPosition = FormStartPosition.Manual;
            int x, y = 0;
            dialg.Text = title;
            dialg.SetText(message);
            dialg.SetButton(button);
            x = form.Location.X + (form.Width / 2) - dialg.Width / 2;
            y = form.Location.Y + form.Height / 2 - dialg.Height / 2;
            dialg.Location = new Point(x, y);
            return dialg.ShowDialog(form);
        }



        public void SetIcon(MessageFormIcon icon)
        {
            switch (icon)
            {
                case MessageFormIcon.None:
                    pIcon.Visible = false;
                    break;
                case MessageFormIcon.OK:
                    pIcon.Image = global::WinForm.UI.Properties.Resources.ok;
                    break;
                case MessageFormIcon.Doubt:
                    pIcon.Image = global::WinForm.UI.Properties.Resources.Doubt;
                    break;

                case MessageFormIcon.Error:
                    pIcon.Image = global::WinForm.UI.Properties.Resources.Error;
                    break;
                case MessageFormIcon.Exclamation:
                    pIcon.Image = global::WinForm.UI.Properties.Resources.Exclamation;
                    break;
                default:
                    break;
            }
        }

        public void SetText(string message)
        {
            //Graphics g= CreateGraphics();
            //SizeF size= g.MeasureString(message,this.lblMessage.Font);
            //int maxW=this.Width-this.lblMessage.Location.X-20;

            //if (size.Width > maxW) 
            //{
            //    int w=Convert.ToInt32( size.Width-maxW);
            //    this.Width =Convert.ToInt32( size.Width + w);
            //}



            if (message.Length > 50)
            {
                //换行
                string newMessage = BreakLongString(message, 50);
                lblMessage.Text = newMessage;
            }
            else
                lblMessage.Text = message;
            int Width = lblMessage.Width;
            int Height = lblMessage.Height;
            if (Width > (this.Width - lblMessage.Location.X - 15))
            {
                this.Width = lblMessage.Location.X + Width + 30;
            }
            if (Height > this.Height - lblMessage.Location.Y)
            {
                this.Height = this.Height + Height;
            }


        }


        public void SetButton(MessageFormButtons button)
        {
            switch (button)
            {
                case MessageFormButtons.YesNo:
                    this.btnOk.Visible = true;
                    this.btnNo.Visible = true;
                    this.DialogResult = DialogResult.No;
                    break;
                case MessageFormButtons.OK:
                    this.btnOk.Visible = true;
                    this.btnNo.Visible = false;
                    this.DialogResult = DialogResult.OK;
                    break;
                default:
                    break;
            }
        }

        public static string BreakLongString(string SubjectString, int lineLength)
        {
            StringBuilder sb = new StringBuilder(SubjectString);
            int offset = 0;
            ArrayList indexList = buildInsertIndexList(SubjectString, lineLength);
            for (int i = 0; i < indexList.Count; i++)
            {
                sb.Insert((int)indexList[i] + offset, '\n');
                offset++;
            }
            return sb.ToString();
        }

        public static bool IsChinese(char c)
        {
            return (int)c >= 0x4E00 && (int)c <= 0x9FA5;
        }

        private static ArrayList buildInsertIndexList(string str, int maxLen)
        {
            int nowLen = 0;
            ArrayList list = new ArrayList();
            for (int i = 1; i < str.Length; i++)
            {
                if (IsChinese(str[i]))
                {
                    nowLen += 2;
                }
                else
                {
                    nowLen++;
                }
                if (nowLen > maxLen)
                {
                    nowLen = 0;
                    list.Add(i);
                }
            }
            return list;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (this.btnNo.Visible)
            {
                FButton button = sender as FButton;
                this.DialogResult = (button.Text.Trim() == "是") ? DialogResult.Yes : DialogResult.No;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            //this.Close();
        }

    }
}
