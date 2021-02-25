﻿//using Syncfusion.UI.Xaml.TreeGrid;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.Forms;

//namespace WinUI_TreeGrid
//{
//    class RequestTreeItemsBehavior : Behavior<SfTreeGrid>
//    {
//        ViewModel viewModel;
//        protected override void OnAttached()
//        {
//            base.OnAttached();
//            viewModel = this.AssociatedObject.DataContext as ViewModel;
//            this.AssociatedObject.RequestTreeItems += AssociatedObject_RequestTreeItems;

//        }

//        void AssociatedObject_RequestTreeItems(object sender, TreeGridRequestTreeItemsEventArgs args)
//        {
//            if (args.ParentItem == null)
//            {
//                //get the root list - get all employees who have no boss 
//                args.ChildItems = viewModel.EmployeeDetails.Where(x => x.ReportsTo == -1); //get all employees whose boss's id is -1 (no boss)
//            }
//            else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
//            {   //get the children of the parent object
//                EmployeeInfo emp = args.ParentItem as EmployeeInfo;
//                if (emp != null)
//                {
//                    //get all employees that report to the parent employee
//                    args.ChildItems = viewModel.GetReportees(emp.ID);
//                }
//            }
//        }

//        protected override void OnDetaching()
//        {
//            base.OnDetaching();
//            this.AssociatedObject.RequestTreeItems -= AssociatedObject_RequestTreeItems;
//        }
//    }
//}
