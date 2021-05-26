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
    public class FinalGradeDAL
    {
        public void UpdateFinalGrade(Grade grade)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.UpdateFinalGrade, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", grade.IdStudent);
                SqlParameter paramIdTeacherSubjectClass = new SqlParameter("@teacher_subject_class_id", grade.IdTeacherSubjectClass);
                SqlParameter paramGradeValue = new SqlParameter("@grade_value", grade.GradeValue);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdTeacherSubjectClass);
                cmd.Parameters.Add(paramGradeValue);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<FinalGrade> GetFinalGradesForStudent(Student student)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetFinalGradesForStudent, con);
                var result = new ObservableCollection<FinalGrade>();
                var paramIdStudent = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdStudent);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var finalGrade = new FinalGrade();
                    finalGrade.IdSubject = (int)(reader[0]);
                    finalGrade.SubjectName = reader.GetString(1);
                    finalGrade.FinalGradeValue = (int)(reader[2]);
                    finalGrade.SemesterName = reader.GetString(3);
                    result.Add(finalGrade);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<SubjectFinalGrade> GetFinalGradesByStudentId(int studentId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetFinalGradesByStudentId, con);
                var result = new ObservableCollection<SubjectFinalGrade>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdTeacher = new SqlParameter("@student_id", studentId);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var subjectFinalGrade = new SubjectFinalGrade();
                    subjectFinalGrade.Id = (int)(reader[0]);
                    subjectFinalGrade.Name = reader.GetString(1);
                    subjectFinalGrade.FinalGrade = (int)(reader[2]);
                    result.Add(subjectFinalGrade);
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
