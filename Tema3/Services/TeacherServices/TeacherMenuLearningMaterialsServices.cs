using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class TeacherMenuLearningMaterialsServices
    {
        private TeacherMenuLearningMaterialsVM _teacherMenuLearningMaterialsVM { get; set; }
        private SubjectYearSpecializationDAL _subjectYearSpecializationDAL { get; set; }
        private LearningMaterialBLL _learningMaterialBLL { get; set; }
        public TeacherMenuLearningMaterialsServices(TeacherMenuLearningMaterialsVM teacherMenuLearningMaterialsVM)
        {
            _learningMaterialBLL = new LearningMaterialBLL();
            _subjectYearSpecializationDAL = new SubjectYearSpecializationDAL();
            _teacherMenuLearningMaterialsVM = teacherMenuLearningMaterialsVM;
        }
        public bool CanAddLearningMaterial(object parameter)
        {
            return !String.IsNullOrWhiteSpace(_teacherMenuLearningMaterialsVM.SelectedFilePath) && _teacherMenuLearningMaterialsVM.SelectedSubjectYearSpecialization != null;
        }
        public void AddLearningMaterial(object parameter)
        {
            try
            {
                var newLearningMaterial = new LearningMaterial(_teacherMenuLearningMaterialsVM.SelectedFilePath);
                _learningMaterialBLL.AddLearningMaterial(newLearningMaterial, _teacherMenuLearningMaterialsVM.SelectedSubjectYearSpecialization.Id);
                _teacherMenuLearningMaterialsVM.LearningMaterialCollection.Add(newLearningMaterial);
            }
            catch(ExistentLearningMaterialException exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public bool CanDeleteLearningMaterial(object parameter)
        {
            return CommonServices.CanExecute(parameter);
        }
        public void DeleteLearningMaterial(object parameter)
        {
            var dataGrid = parameter as DataGrid;
            if (dataGrid != null)
            {
                var rows = (IEnumerable)CommonServices.GetDataGridRows(dataGrid);
                var learningMaterial = new LearningMaterial();
                foreach (DataGridRow row in rows)
                {
                    var columns = dataGrid.Columns;
                    learningMaterial.Id = Convert.ToInt32((columns[0].GetCellContent(row) as TextBlock).Text);
                    learningMaterial.FilePath = (columns[1].GetCellContent(row) as TextBlock).Text;
                    var cellContent = columns[2].GetCellContent(row) as CheckBox;
                    if (cellContent.IsChecked == true)
                    {
                        _learningMaterialBLL.DeleteLearningMaterial(learningMaterial);
                    }
                }
                _teacherMenuLearningMaterialsVM.LearningMaterialCollection = _learningMaterialBLL.GetLearningMaterialsForTeacher(_teacherMenuLearningMaterialsVM.LoggedTeacherId, 
                    _teacherMenuLearningMaterialsVM.SelectedSubjectYearSpecialization.IdSubject);
            }
        }
        public void SelectLearningMaterialPath(object parameter)
        {
            var fileDialog = new OpenFileDialog() { Filter = "txt files(*.txt)|*.txt" };

            var result = fileDialog.ShowDialog();
            if (result == false)
            {
                return;
            }
            else
            {
                _teacherMenuLearningMaterialsVM.SelectedFilePath = fileDialog.FileName;
            }
        }
        public void GetSpecificLearningMaterials()
        {
            _teacherMenuLearningMaterialsVM.LearningMaterialCollection = _learningMaterialBLL.GetLearningMaterialsForTeacher(_teacherMenuLearningMaterialsVM.LoggedTeacherId, _teacherMenuLearningMaterialsVM.SelectedSubjectYearSpecialization.IdSubject);
        }
        public void InitializeFields()
        {
            _teacherMenuLearningMaterialsVM.SubjectYearSpecializationCollection = _subjectYearSpecializationDAL.GetSubjectYearSpecializationForTeacher(_teacherMenuLearningMaterialsVM.LoggedTeacherId);
            _teacherMenuLearningMaterialsVM.DeleteSelectedLearningMaterialsCommand = new RelayCommand(this.DeleteLearningMaterial, this.CanDeleteLearningMaterial);
            _teacherMenuLearningMaterialsVM.SelectLearningMaterialPathCommand = new RelayCommand(this.SelectLearningMaterialPath);
            _teacherMenuLearningMaterialsVM.AddLearningMaterialCommand = new RelayCommand(this.AddLearningMaterial, this.CanAddLearningMaterial);
        }
    }
}
