using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Exceptions;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    public class SubjectBLL
    {
        private SubjectDAL _subjectDAL { get; set; }
        public SubjectBLL()
        {
            _subjectDAL = new SubjectDAL();
        }
        public ObservableCollection<Subject> GetAllSubjects()
        {
            return _subjectDAL.GetAllSubjects();
        }
        public void AddSubject(Subject subject)
        {
            if (!_subjectDAL.SubjectExists(subject))
            {
                _subjectDAL.AddSubject(subject);
            }
            else
            {
                throw new ExistentSubjectException("The table Subject already contains an entry with id " + subject.Id + "!");
            }
        }
        public void DeleteSubject(Subject subject)
        {
            if (_subjectDAL.SubjectExists(subject))
            {
                _subjectDAL.DeleteSubject(subject);
            }
            else
            {
                throw new NonExistentSubjectException("The table Subject doesn't contain an entry with id " + subject.Id + "!");
            }
        }

        public void ModifySubject(Subject subject)
        {
            if (_subjectDAL.SubjectExists(subject))
            {
                _subjectDAL.ModifySubject(subject);
            }
            else
            {
                throw new NonExistentSubjectException("The table Subject doesn't contain an entry with id " + subject.Id + "!");
            }
        }
        
    }
}
