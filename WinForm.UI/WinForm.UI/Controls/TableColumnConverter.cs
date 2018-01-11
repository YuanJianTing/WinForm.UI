using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:15:19
    * 说明：
    * ==========================================================
    * */
    class TableColumnConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// 可否转换到目标类型  
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(TableColumn))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        /// <summary>
        /// 向目标类型转换  
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(TableColumn) && value is TableColumn)
            {

                TableColumn so = (TableColumn)value;
                return so;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>  
        /// 可否从源类型转换  
        /// </summary>  
        /// <param name="context"></param>  
        /// <param name="sourceType">源类型</param>  
        /// <returns></returns>  
        public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
        {
            if (sourceType == typeof(TableColumn))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>  
        /// 从源类型转换  
        /// </summary>  
        /// <param name="context"></param>  
        /// <param name="culture"></param>  
        /// <param name="value">值或引用</param>  
        /// <returns></returns>  
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value != null)
            {
                return (TableColumn)value;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
