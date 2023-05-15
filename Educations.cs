using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78
{
    public class Educations
    {
        public int Id { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }

        private static readonly string connectionString =
         "Data Source=SWHITE;Database=db_Emp;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static int InsertEducation(Educations educations)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations (major,degree,gpa,university_id) VALUES (@major, @Degree, @Gpa, @University_id)";
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

        public static List<Educations> GetEducation()
        {
            var educations = new List<Educations>();
            using SqlConnection connection = new SqlConnection(connectionString);
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
                        var education = new Educations();
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
            return new List<Educations>();
        }

        public static int UpdateEducation(Educations education)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_educations SET major = @major, degree = @degree, gpa = @gpa, university_id = @univ_id WHERE id = @id";
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

        public static int DeleteEducation(Educations educations)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
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

        public void Output()
        {
            Console.WriteLine("");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Major: " + Major);
            Console.WriteLine("Degree: " + Degree);
            Console.WriteLine("GPA: " + GPA);
            Console.WriteLine("Universty Id : " + UniversityId);
            Console.WriteLine("-----------------------------------------");
        }
    }
}
