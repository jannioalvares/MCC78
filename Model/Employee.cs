using MCC78.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Model
{
    public class Employee
    {
        private static readonly string connectionString =
         "Data Source=SWHITE;Database=db_Emp;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public string Id { get; set; }
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentId { get; set; }

        public int InsertEmployee(Employee employees)
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
                    "INSERT INTO tb_m_employees(nik, first_name, last_name, birthdate, gender, hiring_date, email, phone_number, department_id) " +
                    "VALUES (@NIK, @FirstName, @LastName, @Birthdate, @Gender, @HiringDate, @Email, @PhoneNumber, @DepartmentId)";
                command.Transaction = transaction;

                var pNIK = new SqlParameter();
                pNIK.ParameterName = "@NIK";
                pNIK.SqlDbType = SqlDbType.VarChar;
                pNIK.Size = 6;
                pNIK.Value = employees.Nik;
                command.Parameters.Add(pNIK);

                var pFname = new SqlParameter();
                pFname.ParameterName = "@FirstName";
                pFname.SqlDbType = SqlDbType.VarChar;
                pFname.Size = 50;
                pFname.Value = employees.FirstName;
                command.Parameters.Add(pFname);

                var pLname = new SqlParameter();
                pLname.ParameterName = "@LastName";
                pLname.SqlDbType = SqlDbType.VarChar;
                pLname.Size = 50;
                pLname.Value = employees.LastName;
                command.Parameters.Add(pLname);

                var pBday = new SqlParameter();
                pBday.ParameterName = "@Birthdate";
                pBday.Value = employees.Birthdate;
                pBday.SqlDbType = SqlDbType.DateTime;
                command.Parameters.Add(pBday);

                var pGender = new SqlParameter();
                pGender.ParameterName = "@Gender";
                pGender.SqlDbType = SqlDbType.VarChar;
                pGender.Size = 10;
                pGender.Value = employees.Gender;
                command.Parameters.Add(pGender);

                var pHdate = new SqlParameter();
                pHdate.ParameterName = "@HiringDate";
                pBday.SqlDbType = SqlDbType.DateTime;
                pHdate.Value = employees.HiringDate;
                command.Parameters.Add(pHdate);

                var pEmail = new SqlParameter();
                pEmail.ParameterName = "@Email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Size = 50;
                pEmail.Value = employees.Email;
                command.Parameters.Add(pEmail);

                var pNumber = new SqlParameter();
                pNumber.ParameterName = "@PhoneNumber";
                pNumber.SqlDbType = SqlDbType.VarChar;
                pNumber.Size = 20;
                pNumber.Value = employees.PhoneNumber;
                command.Parameters.Add(pNumber);

                var pDepid = new SqlParameter();
                pDepid.ParameterName = "@DepartmentId";
                pDepid.SqlDbType = SqlDbType.Int;
                pDepid.Size = 4;
                pDepid.Value = employees.DepartmentId;
                command.Parameters.Add(pDepid);

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public string GetEmpId(string NIK)
        {
            using SqlConnection connection = MyConnection.Get();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT id FROM tb_m_employees WHERE nik=(@NIK)", connection);

            var niks = new SqlParameter();
            niks.ParameterName = "@NIK";
            niks.Value = NIK;
            command.Parameters.Add(niks);

            string lastEmpId = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return lastEmpId;
        }


        public List<Employee> GetEmployee()
        {
            var employee = new List<Employee>();
            using SqlConnection connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new Employee();
                        emp.Id = reader.GetGuid(0).ToString();
                        emp.Nik = reader.GetString(1);
                        emp.FirstName = reader.GetString(2);
                        emp.LastName = reader.GetString(3);
                        emp.Birthdate = reader.GetDateTime(4);
                        emp.Gender = reader.GetString(5);
                        emp.HiringDate = reader.GetDateTime(6);
                        emp.Email = reader.GetString(7);
                        emp.PhoneNumber = reader.GetString(8);
                        emp.DepartmentId = reader.GetString(9);
                        employee.Add(emp);
                    }

                    return employee;
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

            return new List<Employee>();
        }
    }
}
