using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Tema3.Commands;
using Tema3.Exceptions;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class StudentClassServices
    {
        private StudentClassVM _studentClassVM { get; set; }
        private ClassDAL _classDAL { get; set; }
        private StudentDAL _studentDAL { get; set; }
        private TeacherDAL _teacherDAL { get; set; }
        private HeadTeacherBLL _headTeacherBLL { get; set; }
        public StudentClassServices(StudentClassVM studentClassVM)
        {
            this._studentClassVM = studentClassVM;
            _studentDAL = new StudentDAL();
            _classDAL = new ClassDAL();
            _teacherDAL = new TeacherDAL();
            _headTeacherBLL = new HeadTeacherBLL();
        }
        public void LinkTogether(object parameter)
        {
            try
            {
                _headTeacherBLL.UpdateClassHeadTeacher(_studentClassVM.SelectedClass, _studentClassVM.SelectedTeacher);
                _studentClassVM.SelectedClassHeadTeacher.Id = _studentClassVM.SelectedTeacher.Id;
                _studentClassVM.SelectedClassHeadTeacher.Name = _studentClassVM.SelectedTeacher.Name;
                _studentClassVM.SelectedClassHeadTeacher.IdClass = _studentClassVM.SelectedClass.Id;
            }
            catch (AlreadyHeadTeacherException exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool CanLink(object parameter)
        {
            return _studentClassVM.SelectedClass != null && _studentClassVM.SelectedTeacher != null;
        }
        public void RemoveFromClass(object parameter)
        {
            var dataGrid = parameter as DataGrid;
            if (dataGrid != null)
            {
                var rows = (IEnumerable)GetDataGridRows(dataGrid);
                var updatedCollection = new List<Student>();
                var student = new Student();
                foreach (DataGridRow row in rows)
                {
                    var columns = dataGrid.Columns;
                    student.Id = Convert.ToInt32((columns[0].GetCellContent(row) as TextBlock).Text);
                    student.Name = (columns[1].GetCellContent(row) as TextBlock).Text;
                    student.IdClass = Convert.ToInt32((columns[2].GetCellContent(row) as TextBlock).Text);
                    var cellContent = columns[3].GetCellContent(row) as CheckBox;
                    if (cellContent.IsChecked == true)
                    {
                        updatedCollection = _studentClassVM.StudentCollection.Where(s => s.Id != student.Id).ToList();
                    }
                }
                _studentClassVM.StudentCollection = new ObservableCollection<Student>(updatedCollection);
                _studentDAL.RemoveStudentFromClass(student);
            }
        }
        public bool CanRemoveFromClass(object parameter)
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
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
        public void InitializeFields()
        {
            _studentClassVM.LinkFieldsCommand = new RelayCommand(this.LinkTogether, this.CanLink);
            _studentClassVM.RemoveFromClassCommand = new RelayCommand(this.RemoveFromClass, this.CanRemoveFromClass);
            _studentClassVM.ClassCollection = _classDAL.GetAllClasses();
            _studentClassVM.TeacherCollection = _teacherDAL.GetAllTeachers();
        }
        public void GetStudentsFromSelectedClass(Class selectedClass)
        {
            _studentClassVM.StudentCollection = _studentDAL.GetAllStudentsFromClass(selectedClass);
        }
        public void GetClassHeadTeacher(Class selectedClass)
        {
            _studentClassVM.SelectedClassHeadTeacher = _headTeacherBLL.GetClassHeadTeacher(selectedClass);
        }
    }
}
