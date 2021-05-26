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
    public class LearningMaterialDAL
    {
        public ObservableCollection<LearningMaterial> GetLearningMaterialsForTeacher(int teacherId, int subjectId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetSpecificLearningMaterials, con);
                var result = new ObservableCollection<LearningMaterial>();
                var paramIdClass = new SqlParameter("@teacher_id", teacherId);
                var paramIdSubject = new SqlParameter("@subject_id", subjectId);
                cmd.Parameters.Add(paramIdClass);
                cmd.Parameters.Add(paramIdSubject);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var learningMaterial = new LearningMaterial();
                    learningMaterial.Id = (int)(reader[0]);
                    learningMaterial.FilePath = reader.GetString(1);
                    result.Add(learningMaterial);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }
        public void AddLearningMaterial(LearningMaterial learningMaterial, int idSubjectYearSpecialization)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.AddLearningMaterial, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramLearningMaterialFilePath = new SqlParameter("@learning_material_path", learningMaterial.FilePath);
                SqlParameter paramIdSubjectYearSpecialization = new SqlParameter("@subject_year_specialization_id", idSubjectYearSpecialization);
                cmd.Parameters.Add(paramLearningMaterialFilePath);
                cmd.Parameters.Add(paramIdSubjectYearSpecialization);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool LearningMaterialExists(LearningMaterial learningMaterial)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingLearningMaterial, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramLearningMaterialFilePath = new SqlParameter("@learning_material_path", learningMaterial.FilePath);
                cmd.Parameters.Add(paramLearningMaterialFilePath);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }
        public void DeleteLearningMaterial(LearningMaterial learningMaterial)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.DeleteLearningMaterial, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramLearningMaterialFilePath = new SqlParameter("@learning_material_id", learningMaterial.Id);
                cmd.Parameters.Add(paramLearningMaterialFilePath);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<SubjectLearningMaterial> GetSubjectLearningMaterialsByStudentId(int idStudent)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetSubjectLearningMaterialsByStudentId, con);
                var result = new ObservableCollection<SubjectLearningMaterial>();
                var paramIdStudent = new SqlParameter("@student_id", idStudent);
                cmd.Parameters.Add(paramIdStudent);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var subjectLearningMaterial = new SubjectLearningMaterial();
                    subjectLearningMaterial.IdSubject = (int)(reader[0]);
                    subjectLearningMaterial.SubjectName = reader.GetString(1);
                    subjectLearningMaterial.IdLearningMaterial = (int)(reader[2]);
                    subjectLearningMaterial.LearningMaterialPath = reader.GetString(3);
                    result.Add(subjectLearningMaterial);
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
