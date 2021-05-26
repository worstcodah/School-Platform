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
    public class SpecializationDAL
    {
        public ObservableCollection<Specialization> GetAllSpecializations()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllSpecializations, con);
                var result = new ObservableCollection<Specialization>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var specialization = new Specialization();
                    specialization.Id = (int)(reader[0]);//reader.GetInt(0);
                    specialization.Name = reader.GetString(1);//reader[1].ToString();
                    result.Add(specialization);
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
