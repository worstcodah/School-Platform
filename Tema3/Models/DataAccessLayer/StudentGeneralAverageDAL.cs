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
    public class StudentGeneralAverageDAL
    {
        public ObservableCollection<StudentGeneralAverage> GetStudentsByClassId(int classId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetStudentsFromClass, con);
                var result = new ObservableCollection<StudentGeneralAverage>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@class_id", classId);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var student = new StudentGeneralAverage();
                    student.Id = (int)(reader[0]);//reader.GetInt(0);
                    student.Name = reader.GetString(1);//reader[1].ToString();
                    student.IdClass = (int)(reader[2]);
                    result.Add(student);
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
