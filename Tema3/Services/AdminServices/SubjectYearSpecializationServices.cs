using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class SubjectYearSpecializationServices
    {
        private SubjectYearSpecializationVM _subjectYearSpecializationVM { get; set; }
        private SubjectDAL _subjectDAL { get; set; }
        private YearDAL _yearDAL { get; set; }
        private SemesterDAL _semesterDAL { get; set; }
        private SpecializationDAL _specializationDAL { get; set; }
        private SubjectYearSpecializationDAL _subjectYearSpecializationDAL { get; set; }
        public SubjectYearSpecializationServices(SubjectYearSpecializationVM subjectYearSpecializationVM)
        {
            _semesterDAL = new SemesterDAL();
            _subjectDAL = new SubjectDAL();
            _yearDAL = new YearDAL();
            _specializationDAL = new SpecializationDAL();
            _subjectYearSpecializationDAL = new SubjectYearSpecializationDAL();
            this._subjectYearSpecializationVM = subjectYearSpecializationVM;
        }

        public bool CanLink(object parameter)
        {
            return _subjectYearSpecializationVM.SelectedSpecialization != null && _subjectYearSpecializationVM.SelectedYear != null &&
                _subjectYearSpecializationVM.SelectedSubject != null && _subjectYearSpecializationVM.SelectedThesisChoice != null
                && _subjectYearSpecializationVM.SelectedSemester != null;
        }
        public void LinkTogether(object parameter)
        {
            bool isThesis;
            switch (_subjectYearSpecializationVM.SelectedThesisChoice)
            {
                case "Thesis Subject":
                    isThesis = true;
                    break;
                default:
                    isThesis = false;
                    break;
            }
            var newJoinEntity = new
                SubjectYearSpecialization(_subjectYearSpecializationVM.SelectedSubject, _subjectYearSpecializationVM.SelectedYear
                , _subjectYearSpecializationVM.SelectedSpecialization, isThesis, _subjectYearSpecializationVM.SelectedSemester.Id, 
                _subjectYearSpecializationVM.SelectedSemester.Name);
            if (!_subjectYearSpecializationDAL.LinkExists(newJoinEntity))
            {
                _subjectYearSpecializationVM.SubjectYearSpecializationCollection.Add(newJoinEntity);
                _subjectYearSpecializationDAL.InsertInJoinTable(newJoinEntity);
            }
            else
            {
                _subjectYearSpecializationDAL.UpdateJoinTable(newJoinEntity);
                _subjectYearSpecializationVM.SubjectYearSpecializationCollection = _subjectYearSpecializationDAL.
                    GetAllSubjectYearSpecialization();
            }
        }

        public void InitializeCollections()
        {
            _subjectYearSpecializationVM.ThesisChoices = new List<String>();
            _subjectYearSpecializationVM.SubjectCollection = _subjectDAL.GetAllSubjects();
            _subjectYearSpecializationVM.YearCollection = _yearDAL.GetAllYears();
            _subjectYearSpecializationVM.SpecializationCollection = _specializationDAL.GetAllSpecializations();
            _subjectYearSpecializationVM.SubjectYearSpecializationCollection = _subjectYearSpecializationDAL.GetAllSubjectYearSpecialization();
            _subjectYearSpecializationVM.ThesisChoices.Add("Thesis Subject");
            _subjectYearSpecializationVM.ThesisChoices.Add("Not Thesis Subject");
            _subjectYearSpecializationVM.SemesterCollection = _semesterDAL.GetAllSemesters();
        }

    }
}
