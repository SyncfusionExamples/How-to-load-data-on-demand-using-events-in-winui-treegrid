# How to load data on demand using events in WinUI TreeGrid

This examples describes how to load data on demand using events in [WinUI TreeGrid](https://www.syncfusion.com/winui-controls/treegrid) (SfTreeGrid).

SfTreeGrid supports to load the data in on-demand through [SfTreeGrid.RequestTreeItems](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_RequestTreeItems) event. `RequestTreeItems` event is triggered at the time of loading and when user expand any node at runtime. SfTreeGrid gets the root and leaf nodes through this event handler.

`TreeGridRequestTreeItemsEventArgs.ParentItem` denotes the data object looking for its child nodes. If it is null, it denotes SfTreeGrid requesting root nodes.

In the below example SfTreeGrid is populated through `SfTreeGrid.RequestTreeItems` instead of setting [SfTreeGrid.ItemsSource](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_ItemsSource).

``` csharp
treeGrid.RequestTreeItems += TreeGrid_RequestTreeItems;

private void TreeGrid_RequestTreeItems(object sender, TreeGridRequestTreeItemsEventArgs e)
{
    if (e.ParentItem == null)
    {
        //get the root list - get all employees who have no boss 
        e.ChildItems = (this.treeGrid.DataContext as ViewModel).EmployeeDetails.Where(x => x.ReportsTo == -1); //get all employees whose boss's id is -1 (no boss)
    }
    else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
    {   //get the children of the parent object
        EmployeeInfo emp = e.ParentItem as EmployeeInfo;
        if (emp != null)
        {
            //get all employees that report to the parent employee
            e.ChildItems = (this.treeGrid.DataContext as ViewModel).GetReportees(emp.ID);
        }
    }
}
```