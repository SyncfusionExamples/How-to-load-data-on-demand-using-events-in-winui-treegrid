using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Grids.ScrollAxis;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using Syncfusion.UI.Xaml.TreeGrid;
using System.Globalization;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            treeGrid.RequestTreeItems += TreeGrid_RequestTreeItems;
        }

        private void TreeGrid_RequestTreeItems(object sender, TreeGridRequestTreeItemsEventArgs e)
        {
            if (e.ParentItem == null)
            {
                //get the root list - get all employees who have no boss 
                e.ChildItems = (this.DataContext as ViewModel).EmployeeDetails.Where(x => x.ReportsTo == -1); //get all employees whose boss's id is -1 (no boss)
            }
            else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            {   //get the children of the parent object
                EmployeeInfo emp = e.ParentItem as EmployeeInfo;
                if (emp != null)
                {
                    //get all employees that report to the parent employee
                    e.ChildItems = (this.DataContext as ViewModel).GetReportees(emp.ID);
                }
            }
        }
    }
}
