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
    public class SubjectYearSpecializationDAL
    {
        public ObservableCollection<SubjectYearSpecialization> GetAllSubjectYearSpecialization()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllSubjectYearSpecialization, con);
                var result = new ObservableCollection<SubjectYearSpecialization>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var subjectYearSpecialization = new SubjectYearSpecialization();
                    subjectYearSpecialization.IdSubject = (int)(reader[0]);//reader.GetInt(0);
                    subjectYearSpecialization.IdYear = reader.GetInt32(1);//reader[1].ToString();
                    subjectYearSpecialization.IdSpecialization = reader.GetInt32(2);
                    subjectYearSpecialization.SubjectName = reader.GetString(3);
                    subjectYearSpecialization.YearName = reader.GetString(4);
                    subjectYearSpecialization.SpecializationName = reader.GetString(5);
                    subjectYearSpecialization.IsThesis = (bool)(reader[6]);
                    subjectYearSpecialization.Id = (int)(reader[7]);
                    subjectYearSpecialization.IdSemester = (int)(reader[8]);
                    subjectYearSpecialization.SemesterName = reader.GetString(9);
                    result.Add(subjectYearSpecialization);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<SubjectYearSpecialization> GetSubjectYearSpecializationForTeacher(int teacherId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetSubjectYearSpecializationForTeacher, con);
                var result = new ObservableCollection<SubjectYearSpecialization>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@teacher_id", teacherId);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var subjectYearSpecialization = new SubjectYearSpecialization();
                    subjectYearSpecialization.Id = (int)(reader[0]);
                    subjectYearSpecialization.IdSubject = (int)(reader[1]);
                    subjectYearSpecialization.SubjectName = reader.GetString(2);
                    subjectYearSpecialization.IdYear = (int)(reader[3]);
                    subjectYearSpecialization.YearName = reader.GetString(4);
                    subjectYearSpecialization.IdSpecialization = (int)(reader[5]);
                    subjectYearSpecialization.SpecializationName = reader.GetString(6);
                    subjectYearSpecialization.IdSemester = (int)(reader[7]);
                    subjectYearSpecialization.SemesterName = reader.GetString(8);
                    result.Add(subjectYearSpecialization);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public bool LinkExists(SubjectYearSpecialization subjectYearSpecialization)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingSubjectYearSpecialization, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", subjectYearSpecialization.IdSubject);
                SqlParameter paramIdYear = new SqlParameter("@year_id", subjectYearSpecialization.IdYear);
                SqlParameter paramIdSpecialization = new SqlParameter("@specialization_id", subjectYearSpecialization.IdSpecialization);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdYear);
                cmd.Parameters.Add(paramIdSpecialization);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }

        }
        public void InsertInJoinTable(SubjectYearSpecialization subjectYearSpecialization)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.InsertSubjectYearSpecialization, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", subjectYearSpecialization.IdSubject);
                SqlParameter paramIdYear = new SqlParameter("@year_id", subjectYearSpecialization.IdYear);
                SqlParameter paramIdSpecialization = new SqlParameter("@specialization_id", subjectYearSpecialization.IdSpecialization);
                SqlParameter paramIdSemester = new SqlParameter("@semester_id", subjectYearSpecialization.IdSemester);
                SqlParameter paramIsThesis = new SqlParameter("@is_thesis", subjectYearSpecialization.IsThesis);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdYear);
                cmd.Parameters.Add(paramIdSpecialization);
                cmd.Parameters.Add(paramIsThesis);
                cmd.Parameters.Add(paramIdSemester);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateJoinTable(SubjectYearSpecialization subjectYearSpecialization)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.UpdateSubjectYearSpecialization, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", subjectYearSpecialization.IdSubject);
                SqlParameter paramIdYear = new SqlParameter("@year_id", subjectYearSpecialization.IdYear);
                SqlParameter paramIdSpecialization = new SqlParameter("@specialization_id", subjectYearSpecialization.IdSpecialization);
                SqlParameter paramIsThesis = new SqlParameter("@is_thesis", subjectYearSpecialization.IsThesis);
                SqlParameter paramIdSemester = new SqlParameter("@semester_id", subjectYearSpecialization.IdSemester);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdYear);
                cmd.Parameters.Add(paramIdSpecialization);
                cmd.Parameters.Add(paramIsThesis);
                cmd.Parameters.Add(paramIdSemester);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
