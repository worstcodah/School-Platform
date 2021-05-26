using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Constants
{
    public static class Constants
    {
        public const string ConnectionString = "Data Source=DESKTOP-217KIG6;Initial Catalog=School;Integrated Security=True";
        public const int MaxNoAbsences = 2;
        public enum EntityType
        {
            ADMIN = 1,
            STUDENT,
            TEACHER,
            HEADTEACHER,
            SUBJECT
        }
        public const string GetStudentNameByStudentId = "GetStudentNameByStudentId";
        public const string GetClassNameByStudentId = "GetClassNameByStudentId";
        public const string GetFinalGradesByStudentId = "GetFinalGradesByStudentId";
        public const string GetAbsencesByStudentId = "GetAbsencesByStudentId";
        public const string GetAllStudents = "GetAllStudents";
        public const string GetSpecificStudents = "GetSpecificStudents";
        public const string GetAllStudentsFromClass = "GetAllStudentsFromClass";
        public const string GetAllUsers = "GetAllUsers";
        public const string GetAbsencesForTeacher = "GetAbsencesForTeacher";
        public const string GetGradesForStudent = "GetGradesForStudent";
        public const string IsThesisSubject = "IsThesisSubject";
        public const string GetSubjectYearSpecializationForTeacher = "GetSubjectYearSpecializationForTeacher";
        public const string GetTeacherSubjectClassID = "GetTeacherSubjectClassID";
        public const string AddAbsentee = "AddAbsentee";
        public const string AddLearningMaterial = "AddLearningMaterial";
        public const string CheckForExistingLearningMaterial = "CheckForExistingLearningMaterial";
        public const string DeleteLearningMaterial = "DeleteLearningMaterial";
        public const string AddGrade = "AddGrade";
        public const string UpdateFinalGrade = "UpdateFinalGrade";
        public const string RemoveGrade = "RemoveGrade";
        public const string MotivateAbsence = "MotivateAbsence";
        public const string GetStudentsForTeacher = "GetStudentsForTeacher";
        public const string GetAbsencesForStudent = "GetAbsencesForStudent";
        public const string GetAllAbsencesForClass = "GetAllAbsencesForClass";
        public const string GetAllUnjustifiedAbsencesForClass = "GetAllUnjustifiedAbsencesForClass";
        public const string GetAllUnjustifiedAbsencesForStudent = "GetAllUnjustifiedAbsencesForStudent";
        public const string GetFinalGradesForStudent = "GetFinalGradesForStudent";
        public const string GetFinalGradesForClass = "GetFinalGradesForClass";
        public const string GetSubjectLearningMaterialsByStudentId = "GetSubjectLearningMaterialsByStudentId";
        public const string GetGradesByStudentId = "GetGradesByStudentId";
        public const string GetAllAbsencesForStudent = "GetAllAbsencesForStudent";
        public const string GetNoAbsencesForStudent = "GetNoAbsencesForStudent";
        public const string GetNoUnjustifiedAbsencesForStudent = "GetNoUnjustifiedAbsencesForStudent";
        public const string GetNoAbsencesForClass = "GetNoAbsencesForClass";
        public const string GetNoUnjustifiedAbsencesForClass = "GetNoUnjustifiedAbsencesForClass";
        public const string GetSubjectClassForTeacher = "GetSubjectClassForTeacher";
        public const string GetGradeCollectionItemsForTeacher = "GetGradeCollectionItemsForTeacher";
        public const string GetSpecificLearningMaterials = "GetSpecificLearningMaterials";
        public const string GetAllTeachers = "GetAllTeachers";
        public const string GetAllSemesters = "GetAllSemesters";
        public const string GetAllHeadTeachers = "GetAllHeadTeachers";
        public const string GetClassHeadTeacher = "GetClassHeadTeacher";
        public const string UpdateClassHeadTeacher = "UpdateClassHeadTeacher";
        public const string UpdateTeacherSubjectClass = "UpdateTeacherSubjectClass";
        public const string RemoveStudentFromClass = "RemoveStudentFromClass";
        public const string GetAllSubjects = "GetAllSubjects";
        public const string AddStudent = "AddStudent";
        public const string DeleteStudent = "DeleteStudent";
        public const string ModifyStudent = "ModifyStudent";
        public const string GetStudentsFromClass = "GetStudentsFromClass";
        public const string AddTeacher = "AddTeacher";
        public const string DeleteTeacher = "DeleteTeacher";
        public const string ModifyTeacher = "ModifyTeacher";
        public const string AddSubject = "AddSubject";
        public const string GetHeadTeacherClassId = "GetHeadTeacherClassId";
        public const string GetHeadTeacherClassName = "GetHeadTeacherClassName";
        public const string DeleteSubject = "DeleteSubject";
        public const string ModifySubject = "ModifySubject";
        public const string GetAllSubjectYearSpecialization = "GetAllSubjectYearSpecialization";
        public const string GetAllSpecializations = "GetAllSpecializations";
        public const string GetAllYears = "GetAllYears";
        public const string InsertSubjectYearSpecialization = "InsertSubjectYearSpecialization";
        public const string UpdateSubjectYearSpecialization = "UpdateSubjectYearSpecialization";
        public const string CheckForExistingSubjectYearSpecialization = "CheckForExistingSubjectYearSpecialization";
        public const string CheckForExistingGrade = "CheckForExistingGrade";
        public const string CheckForExistingAbsentee = "CheckForExistingAbsentee";
        public const string CheckForExistingTeacherSubjectClass = "CheckForExistingTeacherSubjectClass";
        public const string CheckForExistingStudent = "CheckForExistingStudent";
        public const string CheckForExistingTeacher = "CheckForExistingTeacher";
        public const string CheckForExistingSubject = "CheckForExistingSubject";
        public const string CheckForExistingHeadTeacher = "CheckForExistingHeadTeacher";
        public const string GetAllClasses = "GetAllClasses";
        public const string GetAllTeacherSubjectClass = "GetAllTeacherSubjectClass";
        public const string InsertTeacherSubjectClass = "InsertTeacherSubjectClass";
    }
}
