# WinForm.UI
WinForm 皮肤，自定义控件
##### 使用方式：
###### BaseForm：
```C#
public partial class MainForm : BaseForm //修改父类 Form 为 BaseForm
```
###### Table ：
#### table支持列、行 拖动；点击标题排序；
#### 当数据源更改时，需调用以下方法：
```C#
table.NotifyDataSetChanged();
```
###### RecyclerView 使用如下
```C#
//需要配合自定义适配器使用，继承 BaseAdapter：
//重新 OnCreateViewHolder(Control control, int offset, int position)、OnDrawItem(Graphics g, ViewHolder viewHolder, int position)
public class ContactsAdapter : BaseAdapter<ContactsViewModel>{
  
}
```

## 效果图：
### Form 、RecyclerView、TreeView
![image](https://github.com/YuanJianTing/WinForm.UI/blob/master/screenshot/20201014182209.png)

## Table
![image](https://github.com/YuanJianTing/WinForm.UI/blob/master/screenshot/20201014182243.png)
![image](https://github.com/YuanJianTing/WinForm.UI/blob/master/screenshot/20201014182258.png)
