using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows;
using Tema3.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.DataAccessLayer
{
    public class AbsenteeDAL
    {
        public void AddAbsentee(Absentee absentee)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                string[] formats = { "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy", "MM/dd/yyyy" };
                SqlCommand cmd = new SqlCommand(Constants.Constants.AddAbsentee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", absentee.IdStudent);
                SqlParameter paramIdTeacherSubjectClass = new SqlParameter("@teacher_subject_class_id", absentee.IdTeacherSubjectClass);
                SqlParameter paramIsMotivated = new SqlParameter("@is_motivated", absentee.IsMotivated);
                SqlParameter paramDate = new SqlParameter("@date", absentee.Date);
                SqlParameter paramSemester = new SqlParameter("@id_semester", absentee.IdSemester);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdTeacherSubjectClass);
                cmd.Parameters.Add(paramIsMotivated);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramSemester);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
