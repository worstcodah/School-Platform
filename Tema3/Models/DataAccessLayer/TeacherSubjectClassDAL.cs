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
    public class TeacherSubjectClassDAL
    {
        public ObservableCollection<TeacherSubjectClass> GetAllTeacherSubjectClass()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllTeacherSubjectClass, con);
                var result = new ObservableCollection<TeacherSubjectClass>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var teacherSubjectClass = new TeacherSubjectClass();
                    teacherSubjectClass.IdSubject = (int)(reader[0]);//reader.GetInt(0);
                    teacherSubjectClass.IdTeacher = (int)(reader[1]);
                    teacherSubjectClass.IdClass = (int)(reader[2]);
                    teacherSubjectClass.ClassName = reader.GetString(3);
                    teacherSubjectClass.TeacherName = reader.GetString(4);
                    teacherSubjectClass.SubjectName = reader.GetString(5);

                    result.Add(teacherSubjectClass);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }
        public void InsertInJoinTable(TeacherSubjectClass teacherSubjectClass)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.InsertTeacherSubjectClass, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacherSubjectClass.IdTeacher);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", teacherSubjectClass.IdSubject);
                SqlParameter paramIdClass = new SqlParameter("@class_id", teacherSubjectClass.IdClass);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateJoinTable(TeacherSubjectClass teacherSubjectClass)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.UpdateTeacherSubjectClass, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacherSubjectClass.IdTeacher);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", teacherSubjectClass.IdSubject);
                SqlParameter paramIdClass = new SqlParameter("@class_id", teacherSubjectClass.IdClass);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool LinkExists(TeacherSubjectClass teacherSubjectClass)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingTeacherSubjectClass, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", teacherSubjectClass.IdSubject);
                SqlParameter paramIdClass = new SqlParameter("@class_id", teacherSubjectClass.IdClass);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                var result = cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }
        public bool IsThesisSubject(int idTeacherSubjectClass)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.IsThesisSubject, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@teacher_subject_class_id", idTeacherSubjectClass);
                cmd.Parameters.Add(paramIdSubject);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Bit);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                var result = cmd.ExecuteNonQuery();
                return Convert.ToBoolean(returnParameter.Value);
            }
        }
        public int GetTeacherSubjectClassId(int classId, int subjectId, int teacherId) 
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetTeacherSubjectClassID, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacherId);
                SqlParameter paramIdClass = new SqlParameter("@class_id", classId);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", subjectId);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                var result = cmd.ExecuteNonQuery();
                return Convert.ToInt32(returnParameter.Value);
            }
        }

    }
}
