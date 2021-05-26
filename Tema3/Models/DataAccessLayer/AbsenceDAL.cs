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
    public class AbsenceDAL
    {
        public ObservableCollection<Absence> GetAbsencesForTeacher(int teacherId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAbsencesForTeacher, con);
                var result = new ObservableCollection<Absence>();
                var paramIdClass = new SqlParameter("@teacher_id", teacherId);
                cmd.Parameters.Add(paramIdClass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var absence = new Absence();
                    absence.Id = (int)(reader[0]);
                    absence.IdStudent = (int)(reader[1]);//reader.GetInt(0);
                    absence.StudentName = reader.GetString(2);//reader[1].ToString();
                    absence.IdClass = (int)(reader[3]);
                    absence.ClassName = reader.GetString(4);
                    absence.IdSpecialization = (int)(reader[5]);
                    absence.SpecializationName = reader.GetString(6);
                    absence.IdYear = (int)(reader[7]);
                    absence.YearName = reader.GetString(8);
                    absence.IdSubject = (int)(reader[9]);
                    absence.SubjectName = reader.GetString(10);
                    absence.IsMotivated = (bool)(reader[11]);
                    absence.Date = (((reader[12])).ToString());
                    absence.IdSemester = ((int)((reader[13])));
                    result.Add(absence);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void MotivateAbsence(Absence absence)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.MotivateAbsence, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbsence = new SqlParameter("@absence_id", absence.Id);
                cmd.Parameters.Add(paramIdAbsence);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool AbsenceExists(Absence absence)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingAbsentee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", absence.IdStudent);
                SqlParameter paramDate = new SqlParameter("@date", absence.Date);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", absence.IdSubject);
                SqlParameter paramIdClass = new SqlParameter("@class_id", absence.IdClass);
                var paramIdSemester = new SqlParameter("@semester_id", absence.IdSemester);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdClass);
                cmd.Parameters.Add(paramIdSemester);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }
        public ObservableCollection<Absence> GetAbsencesForStudent(Student student)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAbsencesForStudent, con);
                var result = new ObservableCollection<Absence>();
                var paramIdClass = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdClass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var absence = new Absence();
                    absence.Id = (int)(reader[0]);
                    absence.IdSubject = (int)(reader[1]);
                    absence.SubjectName = reader.GetString(2);
                    absence.Date = reader.GetString(3);
                    absence.IsMotivated = (bool)(reader[4]);
                    absence.SemesterName = reader.GetString(5);
                    absence.IdStudent = (int)(reader[6]);
                    result.Add(absence);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Absence> GetUnjustifiedAbsencesForStudent(Student student)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllUnjustifiedAbsencesForStudent, con);
                var result = new ObservableCollection<Absence>();
                var paramIdClass = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdClass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var absence = new Absence();
                    absence.Id = (int)(reader[0]);
                    absence.StudentName = reader.GetString(1);
                    absence.IdSubject = (int)(reader[2]);
                    absence.SubjectName = reader.GetString(3);
                    absence.Date = reader.GetString(4);
                    absence.SemesterName = reader.GetString(5);
                    result.Add(absence);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Absence> GetAllAbsencesForStudent(Student student)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllAbsencesForStudent, con);
                var result = new ObservableCollection<Absence>();
                var paramIdClass = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdClass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var absence = new Absence();
                    absence.Id = (int)(reader[0]);
                    absence.StudentName = reader.GetString(1);
                    absence.IdSubject = (int)(reader[2]);
                    absence.SubjectName = reader.GetString(3);
                    absence.Date = reader.GetString(4);
                    absence.SemesterName = reader.GetString(5);
                    result.Add(absence);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Absence> GetAllAbsencesForClass(int classId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllAbsencesForClass, con);
                var result = new ObservableCollection<Absence>();
                var paramIdClass = new SqlParameter("@class_id", classId);
                cmd.Parameters.Add(paramIdClass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var absence = new Absence();
                    absence.Id = (int)(reader[0]);
                    absence.StudentName = reader.GetString(1);
                    absence.IdSubject = (int)(reader[2]);
                    absence.SubjectName = reader.GetString(3);
                    absence.Date = reader.GetString(4);
                    absence.SemesterName = reader.GetString(5);
                    result.Add(absence);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Absence> GetUnjustifiedAbsencesForClass(int classId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllUnjustifiedAbsencesForClass, con);
                var result = new ObservableCollection<Absence>();
                var paramIdClass = new SqlParameter("@class_id", classId);
                cmd.Parameters.Add(paramIdClass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var absence = new Absence();
                    absence.Id = (int)(reader[0]);
                    absence.StudentName = reader.GetString(1);
                    absence.IdSubject = (int)(reader[2]);
                    absence.SubjectName = reader.GetString(3);
                    absence.Date = reader.GetString(4);
                    absence.SemesterName = reader.GetString(5);
                    result.Add(absence);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public int GetNoAbsencesForStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetNoAbsencesForStudent, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbsence = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdAbsence);
                cmd.Parameters.Add("@no_absences", SqlDbType.Int);
                cmd.Parameters["@no_absences"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@no_absences"].Value;
            }
        }
        public int GetNoUnjustifiedAbsencesForStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetNoUnjustifiedAbsencesForStudent, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbsence = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdAbsence);
                cmd.Parameters.Add("@no_absences", SqlDbType.Int);
                cmd.Parameters["@no_absences"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@no_absences"].Value;
            }
        }
        public int GetNoAbsencesForClass(int idClass)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetNoAbsencesForClass, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbsence = new SqlParameter("@class_id", idClass);
                cmd.Parameters.Add(paramIdAbsence);
                cmd.Parameters.Add("@no_absences", SqlDbType.Int);
                cmd.Parameters["@no_absences"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@no_absences"].Value;
            }
        }
        public int GetNoUnjustifiedAbsencesForClass(int idClass)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetNoUnjustifiedAbsencesForClass, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbsence = new SqlParameter("@class_id", idClass);
                cmd.Parameters.Add(paramIdAbsence);
                cmd.Parameters.Add("@no_absences", SqlDbType.Int);
                cmd.Parameters["@no_absences"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@no_absences"].Value;
            }
        }
        public ObservableCollection<Absence> GetAbsencesByStudentId(int studentId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAbsencesByStudentId, con);
                var result = new ObservableCollection<Absence>();
                var paramIdStudent = new SqlParameter("@student_id", studentId);
                cmd.Parameters.Add(paramIdStudent);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var absence = new Absence();
                    absence.IdSubject = (int)(reader[0]);
                    absence.SubjectName = reader.GetString(1);
                    absence.Date = reader.GetString(2);
                    absence.IsMotivated = (bool)(reader[3]);
                    absence.SemesterName = reader.GetString(4);
                    result.Add(absence);
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
