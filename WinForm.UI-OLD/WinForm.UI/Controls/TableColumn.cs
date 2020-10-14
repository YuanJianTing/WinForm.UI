using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Enums;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:14:32
    * 说明：
    * ==========================================================
    * */
    [DefaultProperty("Text"), DesignTimeVisible(false), ToolboxItem(false), TypeConverter(typeof(TableColumnConverter))]
    public class TableColumn : Component, ICloneable, IComparable
    {
        public TableColumn()
        {
        }

        private string name;
        private string text;
        private int width = 60;
        private bool visible = true;

        private Color foreColor = Color.Black;
        [Description("获取或设置次列的字体颜色")]
        public Color ForeColor
        {
            set { foreColor = value; }
            get { return foreColor; }
        }
        private object userData;
        private HorizontalAlignment textAlign = HorizontalAlignment.Center;
        private int displayIndexInternal = -1;
        private Font font;
        private string bindingData;
        [Description("获取或设置绑定数据源名称")]
        public string BindingData
        {
            get { return bindingData; }
            set { bindingData = value; }
        }
        public Font Font
        {
            get {
                if (font == null && table != null)
                    return table.Font;
                return font; }
            set { font = value; }
        }

        public CellStyleType CellStyleType { get; set; } = CellStyleType.Text;

        private FTable table;
        internal FTable OwnerTable
        {
            get
            {
                return this.table;
            }
            set
            {
                this.table = value;
            }
        }


        public bool Visible
        {
            set { visible = value; }
            get { return visible; }
        }


        [Localizable(true), RefreshProperties(RefreshProperties.Repaint), IODescription("ColumnHeaderDisplayIndexDescr")]
        public int DisplayIndex
        {
            get
            {
                return this.displayIndexInternal;
            }
            set
            {
                this.displayIndexInternal = value;
            }
        }


        [Browsable(false)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                {
                    this.name = "";
                }
                else
                {
                    this.name = value;
                }
                if (this.Site != null)
                {
                    this.Site.Name = value;
                }
            }
        }

        [Localizable(true)]
        public string Text
        {
            get
            {
                if (this.text == null)
                {
                    return "ColumnHeader";
                }
                return this.text;
            }
            set
            {
                if (value == null)
                {
                    this.text = "";
                }
                else
                {
                    this.text = value;
                }
            }
        }


        [DefaultValue(HorizontalAlignment.Left), Localizable(true)]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this.textAlign;
            }
            set
            {
                this.textAlign = value;
            }
        }


        [Bindable(true), DefaultValue(null), Localizable(false), TypeConverter(typeof(StringConverter))]
        public object Tag
        {
            get
            {
                return this.userData;
            }
            set
            {
                this.userData = value;
            }
        }


        [DefaultValue(60), Localizable(true)]
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }





        public object Clone()
        {
            Type type = base.GetType();
            TableColumn columnHeader;
            if (type == typeof(ColumnHeader))
            {
                columnHeader = new TableColumn();
            }
            else
            {
                columnHeader = (TableColumn)Activator.CreateInstance(type);
            }
            columnHeader.text = this.text;
            columnHeader.Width = this.width;
            columnHeader.textAlign = this.TextAlign;
            return columnHeader;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && this.table != null)
            {
                this.table.Columns.Remove(this);
            }
            base.Dispose(disposing);
        }



        private bool ShouldSerializeName()
        {
            return !string.IsNullOrEmpty(this.name);
        }


        internal bool ShouldSerializeText()
        {
            return this.text != null;
        }

        public int CompareTo(object obj)
        {
            TableColumn temp = obj as TableColumn;
            return this.DisplayIndex.CompareTo(temp.DisplayIndex);
        }

        private Point location;
        [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Point Location
        {
            get { return location; }
            internal set { location = value; }
        }
    }
}
