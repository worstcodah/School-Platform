using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Tema3.DataAccessLayer
{
    public static class HelperDAL
    {
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(Constants.Constants.ConnectionString);
            }
        }
    }
}
