using MCC78.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Model
{
    public class Education
    {
        public int Id { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }

        public int InsertEducation(Education educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText =
                    "INSERT INTO tb_m_educations (major,degree,gpa,university_id) VALUES (@major, @Degree, @Gpa, @University_id)";
                command.Transaction = transaction;

                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.SqlDbType = SqlDbType.VarChar;
                pMajor.Size = 100;
                pMajor.Value = educations.Major;
                command.Parameters.Add(pMajor);

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@Degree";
                pDegree.SqlDbType = SqlDbType.VarChar;
                pDegree.Size = 100;
                pDegree.Value = educations.Degree;
                command.Parameters.Add(pDegree);

                var pGpa = new SqlParameter();
                pGpa.ParameterName = "@Gpa";
                pGpa.SqlDbType = SqlDbType.VarChar;
                pGpa.Size = 5;
                pGpa.Value = educations.GPA;
                command.Parameters.Add(pGpa);

                var pUniversity_id = new SqlParameter();
                pUniversity_id.ParameterName = "@University_id";
                pUniversity_id.SqlDbType = SqlDbType.Int;
                pUniversity_id.Value = educations.UniversityId;
                command.Parameters.Add(pUniversity_id);

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }

            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public List<Education> GetEducation()
        {
            var educations = new List<Education>();
            using SqlConnection connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new Education();
                        education.Id = reader.GetInt32(0);
                        education.Major = reader.GetString(1);
                        education.Degree = reader.GetString(2);
                        education.GPA = reader.GetString(3);
                        education.UniversityId = reader.GetInt32(4);

                        educations.Add(education);
                    }

                    return educations;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return new List<Education>();
        }

        public int UpdateEducation(Education education)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText =
                    "UPDATE tb_m_educations SET major = @major, degree = @degree, gpa = @gpa, university_id = @univ_id WHERE id = @id";
                command.Transaction = transaction;

                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.Value = education.Major;

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@degree";
                pDegree.Value = education.Degree;

                var pGpa = new SqlParameter();
                pGpa.ParameterName = "@gpa";
                pGpa.Value = education.GPA;

                var pUniversity_id = new SqlParameter();
                pUniversity_id.ParameterName = "@univ_id";
                pUniversity_id.Value = education.UniversityId;

                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = education.Id;

                command.Parameters.Add(pGpa);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pMajor);
                command.Parameters.Add(pUniversity_id);
                command.Parameters.Add(pId);

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public int DeleteEducation(Education educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_educations WHERE id = (@id)";
                command.Transaction = transaction;

                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = educations.Id;

                command.Parameters.Add(pId);
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public int GetEduId()
        {
            using var connection = MyConnection.Get();
            connection.Open();

            var command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
    }
}
