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
    public class HeadTeacherDAL
    {
        public ObservableCollection<HeadTeacher> GetAllHeadTeachers()
        {
            var con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllHeadTeachers, con);
                var result = new ObservableCollection<HeadTeacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var headTeacher = new HeadTeacher();
                    headTeacher.Id = (int)(reader[0]);//reader.GetInt(0);
                    headTeacher.Name = reader.GetString(1);//reader[1].ToString();
                    headTeacher.IdClass = (int)(reader[2]);
                    result.Add(headTeacher);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public bool IsAlreadyHeadTeacher(int teacherId)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingHeadTeacher, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@head_teacher_id", teacherId);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }
        public HeadTeacher GetClassHeadTeacher(Class @class)
        {
            var con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetClassHeadTeacher, con);
                var result = new ObservableCollection<HeadTeacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@class_id", @class.Id);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var headTeacher = new HeadTeacher();
                while (reader.Read())
                {
                    headTeacher.Id = (int)(reader[0]);//reader.GetInt(0);
                    headTeacher.Name = reader.GetString(1);//reader[1].ToString();
                    headTeacher.IdClass = (int)(reader[2]);
                    
                }
                return headTeacher;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateClassHeadTeacher(Class @class, Teacher teacher)
        {
            var con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.UpdateClassHeadTeacher, con);
                var result = new ObservableCollection<HeadTeacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@class_id", @class.Id);
                var paramIdTeacher = new SqlParameter("@teacher_id", teacher.Id);
                cmd.Parameters.Add(paramIdClass);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
