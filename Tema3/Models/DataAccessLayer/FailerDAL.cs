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
    public class FailerDAL
    {
        public ObservableCollection<Failer> GetFailersByClassId(int classId)
        {

            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetFinalGradesForClass, con);
                var result = new ObservableCollection<Failer>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass= new SqlParameter("@class_id", classId);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var failer = new Failer();
                    failer.IdStudent = (int)(reader[0]);
                    failer.StudentName = (String)(reader[1]);//reader.GetInt(0);
                    failer.IdSubject = (int)(reader[2]);//reader[1].ToString();
                    failer.SubjectName = (String)(reader[3]);
                    failer.FinalGradeValue = (int)(reader[4]);
                    result.Add(failer);
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
