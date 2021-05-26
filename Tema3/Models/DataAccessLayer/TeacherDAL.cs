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
    public class TeacherDAL
    {
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            var con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllTeachers, con);
                var result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = (int)(reader[0]);//reader.GetInt(0);
                    teacher.Name = reader.GetString(1);//reader[1].ToString();
                    result.Add(teacher);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public bool TeacherExists(Teacher teacher)
        {
            using (var con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingTeacher, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@teacher_id", teacher.Id);
                cmd.Parameters.Add(paramId);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            using (var con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.AddTeacher, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@teacher_id", teacher.Id);
                SqlParameter paramTeacherName = new SqlParameter("@teacher_name", teacher.Name);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramTeacherName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.DeleteTeacher, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacher.Id);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyTeacher(Teacher teacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.ModifyTeacher, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacher.Id);
                SqlParameter paramTeacherName = new SqlParameter("@teacher_name", teacher.Name);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramTeacherName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public int HeadTeacherClassId(int teacherId)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetHeadTeacherClassId, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacherId);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value;
            }
        }
        public String HeadTeacherClassString(int teacherId)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetHeadTeacherClassName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacherId);
                cmd.Parameters.Add("@class_name", SqlDbType.VarChar, 50);
                cmd.Parameters["@class_name"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                cmd.ExecuteNonQuery();
                return (String)cmd.Parameters["@class_name"].Value;
            }
        }
    }
}

