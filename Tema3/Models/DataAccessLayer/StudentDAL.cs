using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Tema3.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.DataAccessLayer
{
    public class StudentDAL
    {
        public ObservableCollection<Student> GetAllStudents()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllStudents, con);
                var result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = (int)(reader[0]);//reader.GetInt(0);
                    student.Name = reader.GetString(1);//reader[1].ToString();
                    if (reader[2] == System.DBNull.Value)
                    {
                        student.IdClass = 0;
                    }
                    else
                    {
                        student.IdClass = (int)(reader[2]);
                    }
                    result.Add(student);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Student> GetAllStudentsFromClass(Class @class)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetAllStudentsFromClass, con);
                var result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@class_id", @class.Id);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = (int)(reader[0]);//reader.GetInt(0);
                    student.Name = reader.GetString(1);//reader[1].ToString();
                    student.IdClass = (int)(reader[2]);
                    result.Add(student);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Student> GetStudentsForTeacher(int teacherId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetStudentsForTeacher, con);
                var result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@teacher_id", teacherId);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var student = new Student();
                    student.Id = (int)(reader[0]);//reader.GetInt(0);
                    student.Name = reader.GetString(1);//reader[1].ToString();
                    student.IdClass = (int)(reader[2]);
                    result.Add(student);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void RemoveStudentFromClass(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.RemoveStudentFromClass, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void AddStudent(Student student)
        {
            try
            {
                using (SqlConnection con = HelperDAL.Connection)
                {
                    SqlCommand cmd = new SqlCommand(Constants.Constants.AddStudent, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter("@id", student.Id);
                    SqlParameter paramNume = new SqlParameter("@name", student.Name);
                    var paramIdClass = new SqlParameter("@id_class", student.IdClass);
                    cmd.Parameters.Add(paramId);
                    cmd.Parameters.Add(paramNume);
                    cmd.Parameters.Add(paramIdClass);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.DeleteStudent, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool StudentExists(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.CheckForExistingStudent, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", student.Id);
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                return (int)returnParameter.Value != 0;
            }
        }

        public ObservableCollection<Student> GetStudentsByClassId(int classId)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                var cmd = new SqlCommand(Constants.Constants.GetStudentsFromClass, con);
                var result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                var paramIdClass = new SqlParameter("@class_id", classId);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var student = new Student();
                    student.Id = (int)(reader[0]);//reader.GetInt(0);
                    student.Name = reader.GetString(1);//reader[1].ToString();
                    student.IdClass = (int)(reader[2]);
                    result.Add(student);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void ModifyStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.ModifyStudent, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("student_id", student.Id);
                SqlParameter paramNume = new SqlParameter("@student_name", student.Name);
                var paramIdClass = new SqlParameter("@class_id", student.IdClass);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public String GetClassNameByStudentId(int studentId)
        {

            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetClassNameByStudentId, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", studentId);
                cmd.Parameters.Add("@class_name", SqlDbType.VarChar, 50);
                cmd.Parameters["@class_name"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
                return (String)cmd.Parameters["@class_name"].Value;
            }
        }
        public String GetStudentNameByStudentId(int studentId)
        {

            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand(Constants.Constants.GetStudentNameByStudentId, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", studentId);
                cmd.Parameters.Add("@student_name", SqlDbType.VarChar, 50);
                cmd.Parameters["@student_name"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
                return (String)cmd.Parameters["@student_name"].Value;
            }
        }

    }
}
