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
    public class SubjectDAL
    {
        public ObservableCollection<Subject> GetAllSubjects()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllSubjects, con);
                var result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var subject = new Subject();
                    subject.Id = (int)(reader[0]);//reader.GetInt(0);
                    subject.Name = reader.GetString(1);//reader[1].ToString();
                    result.Add(subject);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public bool SubjectExists(Subject subject)
        {
            using (var con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingSubject, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@subject_id", subject.Id);
                cmd.Parameters.Add(paramId);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }
        public void AddSubject(Subject subject)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.AddSubject, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", subject.Name);
                cmd.Parameters.Add(paramName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteSubject(Subject subject)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.DeleteSubject, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@id", subject.Id);
                cmd.Parameters.Add(paramIdSubject);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifySubject(Subject subject)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.ModifySubject, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("id", subject.Id);
                SqlParameter paramName = new SqlParameter("@name", subject.Name);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
