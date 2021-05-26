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
    public class ClassDAL
    {
        public ObservableCollection<Class> GetAllClasses()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllClasses, con);
                var result = new ObservableCollection<Class>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var @class = new Class();
                    @class.Id = (int)(reader[0]);
                    @class.IdYear = (int)(reader[1]);//reader.GetInt(0);
                    @class.IdSpecialization = (int)(reader[2]);//reader[1].ToString();
                    @class.IdHeadTeacher = (int)(reader[3]);
                    @class.Name = reader.GetString(4);
                    result.Add(@class);
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
