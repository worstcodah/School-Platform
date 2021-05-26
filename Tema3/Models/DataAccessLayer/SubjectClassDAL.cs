using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Tema3.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.DataAccessLayer
{
    public class SubjectClassDAL
    {
        public ObservableCollection<SubjectClass> GetSubjectClassForTeacher(int teacherId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetSubjectClassForTeacher, con);
                var result = new ObservableCollection<SubjectClass>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@teacher_id", teacherId);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var subjectClass = new SubjectClass();
                    subjectClass.IdTeacherSubjectClass = (int)(reader[0]);
                    subjectClass.IdSubject = (int)(reader[1]);
                    subjectClass.IdClass = (int)(reader[2]);
                    subjectClass.IdSpecialization = (int)(reader[3]);
                    subjectClass.IdYear = (int)(reader[4]);
                    subjectClass.IdSemester = (int)(reader[5]);
                    subjectClass.SubjectName = reader.GetString(6);
                    subjectClass.ClassName = reader.GetString(7);
                    subjectClass.SpecializationName = reader.GetString(8);
                    subjectClass.YearName = reader.GetString(9);
                    subjectClass.SemesterName = reader.GetString(10);
                    result.Add(subjectClass);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
