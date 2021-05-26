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
    public class StudentFinalGradeDAL
    {
        public ObservableCollection<StudentFinalGrade> GetSpecificStudents(int teacherId, int specializationId, int yearId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetSpecificStudents, con);
                var result = new ObservableCollection<StudentFinalGrade>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdTeacher = new SqlParameter("@teacher_id", teacherId);
                var paramIdSpecialization = new SqlParameter("@specialization_id", specializationId);
                var paramIdYear = new SqlParameter("@year_id", yearId);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramIdSpecialization);
                cmd.Parameters.Add(paramIdYear);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var studentFinalGrade = new StudentFinalGrade();
                    studentFinalGrade.Id = (int)(reader[0]);//reader.GetInt(0);
                    studentFinalGrade.Name = reader.GetString(1);//reader[1].ToString();
                    studentFinalGrade.IdClass = (int)(reader[2]);
                    studentFinalGrade.FinalGrade= (int)(reader[3]);
                    result.Add(studentFinalGrade);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateFinalGrade(int idTeacherSubjectClass, int gradeValue, int idStudent)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.UpdateFinalGrade, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", idStudent);
                SqlParameter paramIdTeacherSubjectClass = new SqlParameter("@teacher_subject_class_id", idTeacherSubjectClass);
                SqlParameter paramGradeValue = new SqlParameter("@grade_value", gradeValue);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdTeacherSubjectClass);
                cmd.Parameters.Add(paramGradeValue);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
    }
}
