using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Tema3.DataAccessLayer;
using Tema3.Models.EntityLayer;
using static Tema3.Constants.Constants;

namespace Tema3.Models.DataAccessLayer
{
    public class UserDAL
    {
        public bool UserExists(User user)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllUsers, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var dbUser = new User();
                    dbUser.Id = (int)(reader[0]);//reader.GetInt(0);
                    dbUser.UserName = reader.GetString(1);//reader[1].ToString();
                    dbUser.Password = reader.GetString(2);
                    dbUser.UserType = (EntityType)(reader[3]);
                    if (user.Equals(dbUser))
                    {
                        user.UserType = dbUser.UserType;
                        user.Id = dbUser.Id;
                        return true;
                    }

                }
                reader.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
