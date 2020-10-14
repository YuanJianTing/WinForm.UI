using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.UI.Extension
{
    public static class ListExtension
    {
        public static void AddRange(this System.Collections.IList list, System.Collections.IList items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }

    }
}
