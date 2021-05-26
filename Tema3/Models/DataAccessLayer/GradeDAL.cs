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
    public class GradeDAL
    {
        public void AddGrade(Grade grade)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {

                SqlCommand cmd = new SqlCommand(Constants.Constants.AddGrade, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", grade.IdStudent);
                SqlParameter paramIdTeacherSubjectClass = new SqlParameter("@teacher_subject_class_id", grade.IdTeacherSubjectClass);
                SqlParameter paramGradeValue = new SqlParameter("@grade_value", grade.GradeValue);
                SqlParameter paramThesisGrade = new SqlParameter("@is_thesis_grade", grade.IsThesisGrade);
                SqlParameter paramSemester = new SqlParameter("@id_semester", grade.IdSemester);
                SqlParameter paramDate = new SqlParameter("@date", grade.Date);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdTeacherSubjectClass);
                cmd.Parameters.Add(paramThesisGrade);
                cmd.Parameters.Add(paramGradeValue);
                cmd.Parameters.Add(paramSemester);
                cmd.Parameters.Add(paramDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Grade> GetGradesForStudent(Student student)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetGradesForStudent, con);
                var result = new List<Grade>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var grade = new Grade();
                    grade.GradeValue = (int)(reader[0]);//reader.GetInt(0);
                    grade.IdTeacherSubjectClass = (int)(reader[1]);
                    result.Add(grade);
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
