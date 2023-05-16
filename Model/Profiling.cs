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
    public class Profiling
    {
        public string EmployeeId { get; set; }
        public int EducationId { get; set; }

        public int InsertProfiling(Profiling profilings)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();
            var employee = new Employee();
            var education = new Education();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profilings(employee_id, education_id) VALUES (@EmployeeId, @EducationId)";
                command.Transaction = transaction;

                var pEmpId = new SqlParameter();
                pEmpId.ParameterName = "@EmployeeId";
                pEmpId.Value = profilings.EmployeeId;
                command.Parameters.Add(pEmpId);

                var pEduId = new SqlParameter();
                pEduId.ParameterName = "@EducationId";
                pEduId.Value = profilings.EducationId;
                command.Parameters.Add(pEduId);

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

        public List<Profiling> GetProfiling()
        {
            var profiling = new List<Profiling>();
            using SqlConnection connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_profilings";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var prof = new Profiling();
                        prof.EmployeeId = reader.GetGuid(0).ToString();
                        prof.EducationId = reader.GetInt32(1);

                        profiling.Add(prof);
                    }
                    return profiling;
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
            return new List<Profiling>();
        }
    }
}
