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
    public class GradeCollectionItemDAL
    {
        public ObservableCollection<GradeCollectionItem> GetGradeCollectionItemsForTeacher(int teacherId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetGradeCollectionItemsForTeacher, con);
                var result = new ObservableCollection<GradeCollectionItem>();
                var paramIdClass = new SqlParameter("@teacher_id", teacherId);
                cmd.Parameters.Add(paramIdClass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var gradeCollectionItem = new GradeCollectionItem();
                    gradeCollectionItem.Id = (int)(reader[0]);
                    gradeCollectionItem.IdStudent = (int)(reader[1]);//reader.GetInt(0);
                    gradeCollectionItem.StudentName = reader.GetString(2);//reader[1].ToString();
                    gradeCollectionItem.IdClass = (int)(reader[3]);
                    gradeCollectionItem.ClassName = reader.GetString(4);
                    gradeCollectionItem.IdSpecialization = (int)(reader[5]);
                    gradeCollectionItem.SpecializationName = reader.GetString(6);
                    gradeCollectionItem.IdYear = (int)(reader[7]);
                    gradeCollectionItem.YearName = reader.GetString(8);
                    gradeCollectionItem.IdSubject = (int)(reader[9]);
                    gradeCollectionItem.SubjectName = reader.GetString(10);
                    gradeCollectionItem.GradeValue = (int)(reader[11]);
                    gradeCollectionItem.IsThesisGrade = (bool)(reader[12]);
                    gradeCollectionItem.IdSemester = ((int)((reader[13])));
                    gradeCollectionItem.Date = reader.GetString(14);
                    result.Add(gradeCollectionItem);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }
        public bool GradeExists(GradeCollectionItem gradeCollectionItem)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {

                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingGrade, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", gradeCollectionItem.IdStudent);
                SqlParameter paramIdTeacherSubjectClass = new SqlParameter("@subject_id", gradeCollectionItem.IdSubject);
                SqlParameter paramSemester = new SqlParameter("@semester_id", gradeCollectionItem.IdSemester);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdTeacherSubjectClass);
                cmd.Parameters.Add(paramSemester);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }
        public void RemoveGrade(GradeCollectionItem gradeCollectionItem)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.RemoveGrade, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdGrade = new SqlParameter("@grade_id", gradeCollectionItem.Id);
                cmd.Parameters.Add(paramIdGrade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<GradeCollectionItem> GetGradesByStudentId(int idStudent)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetGradesByStudentId, con);
                var result = new ObservableCollection<GradeCollectionItem>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdStudent = new SqlParameter("@student_id", idStudent);
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var gradeCollectionItem = new GradeCollectionItem();
                    gradeCollectionItem.IdSubject = (int)(reader[0]);
                    gradeCollectionItem.SubjectName = reader.GetString(1);
                    gradeCollectionItem.GradeValue = (int)(reader[2]);
                    gradeCollectionItem.Date = reader.GetString(3);
                    result.Add(gradeCollectionItem);
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
