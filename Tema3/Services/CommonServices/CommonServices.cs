using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Tema3.Navigation;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class CommonServices
    {
        public static void Logout(object parameter)
        {
            var viewNavigation = parameter as ViewNavigation;
            viewNavigation.CurrentVM = new LoginVM(viewNavigation);
        }

        public static bool CanExecute(object parameter)
        {
            var dataGrid = parameter as DataGrid;
            if (dataGrid != null)
            {
                var rows = (IEnumerable)GetDataGridRows(dataGrid);
                foreach (DataGridRow row in rows)
                {
                    if (row == null)
                    {
                        break;
                    }
                    foreach (DataGridColumn column in dataGrid.Columns)
                    {
                        if (column.GetCellContent(row) is CheckBox)
                        {
                            var cellContent = column.GetCellContent(row) as CheckBox;

                            if (cellContent == null)
                            {
                                break;
                            }

                            if (cellContent.IsChecked == true)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
        public static IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

    }
}
