using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm.UI.Controls.Converters;
using WinForm.UI.Controls.Emuns;
using WinForm.UI.Extension;

namespace WinForm.UI.Controls
{
    [DefaultProperty("Text"), DesignTimeVisible(false), ToolboxItem(false), TypeConverter(typeof(TableColumnConverter))]
    public class TableColumn
    {
        private Color foreColor;
        private Font font;
        private string text;
        private float weight=100;
        private bool sortColumn;
        private int width=60;


        public TableColumn()
        {
        }

        [Bindable(false), Browsable(false)]
        public RectangleF Bounds { get; internal set; }
        [Bindable(false), Browsable(false)]
        public Table Owner { get;internal set; }
        [Bindable(false), Browsable(false)]
        public bool Desc { get; set; }

        [Description("获取或设置当前列显示内容的格式")]
        public string Format { get; set; }

        public DataType DataType { get; set; }

        [DefaultValue(false), Localizable(true)]
        [Description("获取或设置当前列是否支持排序")]
        public bool SortColumn { get { return sortColumn; } set { if (sortColumn == value) return; sortColumn = value; this.Invalidate(); } }

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
                Invalidate();
            }
        }


        [DefaultValue(60), Localizable(true)]
        [Description("获取或设置列的宽度，如果设置了此属性则忽略【Weight】属性")]
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
                Owner?.ResetColumns();
            }
        }

        [DefaultValue(100), Localizable(true)]
        [Description("获取或设置列宽度的百分比，有效值位1~100")]
        public float Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("有效值位1~100");
                this.weight = value;
                this.width = 0;
                Owner?.ResetColumns();
            }
        }



        [Description("获取或设置次列的字体颜色")]
        public Color ForeColor
        {
            get
            {
                if (foreColor==null&& Owner != null)
                    return Owner.ForeColor;
                return foreColor;
            }
            set { foreColor = value; Invalidate(); }
        }

        [Description("获取或设置绑定数据源名称")]
        public string BindingData { get; set; }

        public Font Font
        {
            get
            {
                if (font == null && Owner != null)
                    return Owner.Font;
                return font;
            }
            set { font = value; }
        }

        

        private void Invalidate()
        {
            Owner?.Invalidate(Rectangle.Truncate( Bounds));
        }


        public virtual void Draw(Graphics g,SolidBrush solidBrush,RectangleF Bounds)
        {
            g.DrawNoPaddingStringMiddleCenter(Text, Font, solidBrush, Bounds);
            if (SortColumn)
            {
                PointF[] pntArr = new PointF[3];
                if (Desc)
                {
                    float x = Bounds.Right - 15;
                    float y = Bounds.Bottom - Bounds.Height / 2-2;
                    pntArr[0] = new PointF(x, y);
                    pntArr[1] = new PointF(pntArr[0].X - 5, y+8);
                    pntArr[2] = new PointF(pntArr[0].X + 5, y + 8);
                }
                else
                {
                    float x = Bounds.Right - 20;
                    float y = Bounds.Bottom - Bounds.Height / 2-2;
                    pntArr[0] = new PointF(x, y);
                    pntArr[1] = new PointF(pntArr[0].X+10, y);
                    pntArr[2] = new PointF(x+5,y+5);
                }
                g.FillPolygon(solidBrush, pntArr);
            }
        }

    }
}
