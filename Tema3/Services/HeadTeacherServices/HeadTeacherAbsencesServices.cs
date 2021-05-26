using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Tema3.Commands;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class HeadTeacherAbsencesServices
    {
        private HeadTeacherAbsencesVM _headTeacherAbsencesVM { get; set; }
        private StudentDAL _studentDAL { get; set; }
        private AbsenceDAL _absenceDAL { get; set; }
        public HeadTeacherAbsencesServices(HeadTeacherAbsencesVM headTeacherAbsencesVM)
        {
            _absenceDAL = new AbsenceDAL();
            _studentDAL = new StudentDAL();
            _headTeacherAbsencesVM = headTeacherAbsencesVM;
        }
        public void MotivateAbsences(object parameter)
        {
            var dataGrid = parameter as DataGrid;
            if (dataGrid != null)
            {
                var absence = new Absence();
                var rows = (IEnumerable)CommonServices.GetDataGridRows(dataGrid);
                foreach (DataGridRow row in rows)
                {
                    var columns = dataGrid.Columns;
                    absence.Id = Convert.ToInt32((columns[0].GetCellContent(row) as TextBlock).Text);
                    absence.IdSubject= Convert.ToInt32((columns[1].GetCellContent(row) as TextBlock).Text);
                    absence.SubjectName = (columns[2].GetCellContent(row) as TextBlock).Text;
                    absence.Date = (columns[3].GetCellContent(row) as TextBlock).Text;
                    absence.IsMotivated = Convert.ToBoolean((columns[4].GetCellContent(row) as TextBlock).Text);
                    absence.SemesterName = (columns[5].GetCellContent(row) as TextBlock).Text;
                    var cellContent = columns[6].GetCellContent(row) as CheckBox;
                    if (cellContent.IsChecked == true)
                    {
                        _absenceDAL.MotivateAbsence(absence);
                    }
                }
                _headTeacherAbsencesVM.AbsenceCollection = _absenceDAL.GetAbsencesForStudent(_headTeacherAbsencesVM.SelectedStudent);
            }
        }
        public bool CanMotivateAbsences(object parameter)
        {
            return CommonServices.CanExecute(parameter);
        }
        public void InitializeFields()
        {
            _headTeacherAbsencesVM.MotivateAbsencesCommand = new RelayCommand(this.MotivateAbsences, this.CanMotivateAbsences);
            _headTeacherAbsencesVM.StudentCollection = _studentDAL.GetStudentsByClassId(_headTeacherAbsencesVM.HeadTeacherClassId);           
        }
        public void UpdateAbsenceCollection()
        {

            _headTeacherAbsencesVM.AbsenceCollection = _absenceDAL.GetAbsencesForStudent(_headTeacherAbsencesVM.SelectedStudent);
            var newList = _headTeacherAbsencesVM.AbsenceCollection.Where(s => s.IdStudent ==
               _headTeacherAbsencesVM.SelectedStudent.Id).ToList();
            _headTeacherAbsencesVM.AbsenceCollection = new ObservableCollection<Absence>(newList);
        }
    }
}
