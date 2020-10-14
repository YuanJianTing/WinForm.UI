using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.UI.Controls
{
    public class TableColumnCollection : IList<TableColumn>, ICollection<TableColumn>,
        IEnumerable<TableColumn>, IList, ICollection, IReadOnlyList<TableColumn>, IReadOnlyCollection<TableColumn>, IEnumerable
    {
        private Table owner;
        private List<TableColumn> m_arrItem;

        public TableColumnCollection(Table owner)
        {
            this.owner = owner;
            m_arrItem = new List<TableColumn>();
        }


        public TableColumn this[int index] { get => m_arrItem[index]; set => m_arrItem[index] = value; }
        object IList.this[int index] { get => m_arrItem[index]; set => m_arrItem[index] = value as TableColumn; }

        public int Count => m_arrItem.Count;

        public bool IsReadOnly => false;

        public bool IsFixedSize => true;

        public object SyncRoot => new object();

        public bool IsSynchronized => true;

        public void Add(TableColumn item)
        {
            item.Owner = owner;
            m_arrItem.Add(item);
            owner.Invalidate();
        }

        public int Add(object value)
        {
            Add((value as TableColumn));
            return m_arrItem.Count - 1;
        }

        public void AddRange(IEnumerable<TableColumn> columnHeaders)
        {
            foreach (var item in columnHeaders)
            {
                item.Owner = owner;
            }
            m_arrItem.AddRange(columnHeaders);
            
            owner.Invalidate();
        }

        public void Clear()
        {
            m_arrItem.Clear();
            owner.Invalidate();
        }

        public bool Contains(TableColumn item)
        {
            return m_arrItem.Contains(item);
        }

        public bool Contains(object value)
        {
            return m_arrItem.Contains(value);
        }

        public void CopyTo(TableColumn[] array, int arrayIndex)
        {
            m_arrItem.CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            TableColumn[] list = new TableColumn[array.Length];
            int i = 0;
            foreach (var item in array)
            {
                list[i] = item as TableColumn;
                i++;
            }
            m_arrItem.CopyTo(list, index);
        }

        public IEnumerator<TableColumn> GetEnumerator()
        {
            return m_arrItem.GetEnumerator();
        }

        public int IndexOf(TableColumn item)
        {
            return m_arrItem.IndexOf(item);
        }

        public int IndexOf(object value)
        {
            return m_arrItem.IndexOf((value as TableColumn));
        }

        public void Insert(int index, TableColumn item)
        {
            item.Owner = owner;
            m_arrItem.Insert(index, item);
            owner.Invalidate();
        }

        public void Insert(int index, object value)
        {
            Insert(index, (value as TableColumn));
        }

        public bool Remove(TableColumn item)
        {
            bool result = m_arrItem.Remove(item);
            owner.Invalidate();
            return result;
        }

        public void Remove(object value)
        {
            Remove((value as TableColumn));
        }

        public void RemoveAt(int index)
        {
            m_arrItem.RemoveAt(index);
            owner.Invalidate();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_arrItem.GetEnumerator();
        }

        public void Transposition(int BeforeDragPos,int AfterDragPos)
        {
            TableColumn temp = m_arrItem[BeforeDragPos];
            m_arrItem.Remove(temp);
            m_arrItem.Insert(AfterDragPos, temp);
            //owner.Invalidate();
        }

    }
}
