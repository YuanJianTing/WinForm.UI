using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:10:55
    * 说明：
    * ==========================================================
    * */
    public abstract class BaseAdapter<T> : Adapter
    {
        protected List<T> items;

        public BaseAdapter()
        {
            items = new List<T>();
        }

        public override int GetCount()
        {
            return items.Count;
        }

        public T GetItem(int position)
        {
            return items[position];
        }

        public void Add(T item)
        {
            items.Add(item);
            notifyDataSetChanged();
        }
        public void AddItems(IEnumerable<T> items)
        {
            this.items.AddRange(items);
            notifyDataSetChanged();
        }
        public void SetItems(IEnumerable<T> items)
        {
            this.items.Clear();
            this.items.AddRange(items);
            notifyDataSetChanged();
        }

        public void Clear()
        {
            items.Clear();
            notifyDataSetChanged();
        }
    }
}
