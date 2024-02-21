using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.APP.Mock
{
    public class UserDALMock : IDatabaseConnection
    {
        private string _connectionString;

        public UserDALMock(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool CreateUser(string username, string password, int age)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Users (Username, Password, Age) VALUES ('{username}', '{password}', {age})";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateUserAge(string username, int newAge)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"UPDATE Users SET Age = {newAge} WHERE Username = '{username}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND Password = '{password}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
