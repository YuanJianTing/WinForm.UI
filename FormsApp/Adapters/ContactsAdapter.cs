 using FormsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI;
using WinForm.UI.Controls;
using WinForm.UI.Extension;

namespace FormsApp.Adapters
{
    public class ContactsAdapter : BaseAdapter<ContactsViewModel>
    {
        private const int ITEM_HEIGHT = 60;
        private int x, y;
        private Font nickNameFont;
        private string CachePath;

        public ContactsAdapter(string CachePath)
        {
            this.CachePath = CachePath;
            nickNameFont = new Font("微软雅黑", 10, FontStyle.Regular);
        }


        public override ViewHolder OnCreateViewHolder(Control control, int offset, int position)
        {
            ViewHolder viewHolder = GetViewHolder(position);
            y = position * ITEM_HEIGHT;
            if (viewHolder == null)
            {
                viewHolder = new ViewHolder(control, new Rectangle(x, y + offset, control.Width, ITEM_HEIGHT), position);
                CacheViewHolder(viewHolder);//缓存 ViewHolder
            }
            else
            {
                viewHolder.Bounds = new Rectangle(x, y + offset, control.Width, ITEM_HEIGHT);
            }
            return viewHolder;
        }

        public override void OnDrawItem(Graphics g, ViewHolder viewHolder, int position)
        {
            ContactsViewModel viewModel = GetItem(position);
            Rectangle Bounds = viewHolder.Bounds;

            LoadAsyncImage(g, viewHolder, viewModel.HeadUrl);

            using (SolidBrush solidBrush = new SolidBrush(ColorStyles.ForeColor))
            {
                g.DrawString(viewModel.NickName, nickNameFont, solidBrush, Bounds.X + 47, Bounds.Y + 8);
                g.DrawString(viewModel.Number, nickNameFont, solidBrush, Bounds.X + 47, Bounds.Y + 30);
                
                g.DrawString(viewModel.Time.ToString("HH:mm"), nickNameFont, solidBrush, Bounds.Right - 50, Bounds.Y + 8);
            }
            using (Pen pen = new Pen(ColorStyles.LineColor))
                g.DrawLine(pen, Bounds.X + 30, Bounds.Bottom - 2, Bounds.Width - 5, Bounds.Bottom - 2);
        }

        private void LoadAsyncImage(Graphics g, ViewHolder viewHolder, string url)
        {
            if (string.IsNullOrEmpty(url))
                return;
            string fileName = string.Concat(Encryptor.MD5(url), ".bmp");
            string savePath = Path.Combine(CachePath, fileName);
            if (File.Exists(savePath))
            {
                Bitmap bitmap = new Bitmap(savePath);
                g.DrawStretchImageImage(bitmap, new Rectangle(viewHolder.Bounds.X + 5, viewHolder.Bounds.Y + 8, 40, 40));
                bitmap.Dispose();
                return;
            }

            Task.Run(async () =>
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    byte[] buffer = await httpClient.GetByteArrayAsync(url);
                    Bitmap bitmap = new Bitmap(new MemoryStream(buffer));
                    return bitmap;
                }
            }).ContinueWith(o =>
            {
                if (o.Status == TaskStatus.RanToCompletion)
                {
                    if (!File.Exists(savePath))
                    {
                        o.Result.Save(savePath);
                        return true;
                    }
                }
                return false;
            })
                .ContinueWith(o =>
            {
                if (o.Result)
                {
                    viewHolder.Control.Invoke(new EventHandler(delegate
                    {
                        viewHolder.Control.Invalidate(viewHolder.Bounds);
                    }));
                }
            });
        }

    }
}
