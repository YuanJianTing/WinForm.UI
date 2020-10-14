using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.UI.Controls
{
    public abstract class BaseAdapter<T> : Adapter<ViewHolder>
    {
        private List<T> items;
        private List<ViewHolder> holdersList;

        public BaseAdapter()
        {
            items = new List<T>();
            holdersList = new List<ViewHolder>();
        }


        public override int GetItemCount()
        {
            return items.Count;
        }


        public T GetItem(int position)
        {
            return items[position];
        }

        public void AddItem(T t)
        {
            items.Add(t);
            NotifyDataSetChanged();
        }

        public void AddItems(IEnumerable<T> collection)
        {
            items.AddRange(collection);
            NotifyDataSetChanged();
        }

        public void SetItems(IEnumerable<T> collection)
        {
            items.Clear();
            holdersList.Clear();
            items.AddRange(collection);
            NotifyDataSetChanged();
        }

        public void Clear()
        {
            holdersList.Clear();
            items.Clear();
            NotifyDataSetChanged();
        }

        public ViewHolder GetViewHolder(int position)
        {
            if (holdersList.Count <= position)
                return null;
            return holdersList[position];
        }

        public void CacheViewHolder(ViewHolder viewHolder)
        {
            holdersList.Add(viewHolder);
        }


    }
}
