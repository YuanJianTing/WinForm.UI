# WinForm.UI
WinForm 皮肤，自定义控件
##### 使用方式：
###### BaseForm：
```C#
public partial class MainForm : BaseForm //修改父类 Form 为 BaseForm
```
###### Table ：
#### table支持列、行 拖动；执行点击标题排序；
#### 当数据源更改时，需调用以下方法：
```C#
table.NotifyDataSetChanged();
```

## 效果图：
### Form 、RecyclerView、TreeView
![image](https://github.com/YuanJianTing/WinForm.UI/tree/master/screenshot/20201014182209.png)

## Table
![image](https://github.com/YuanJianTing/WinForm.UI/tree/master/screenshot/20201014182243.png)
![image](https://github.com/YuanJianTing/WinForm.UI/tree/master/screenshot/20201014182258.png)
