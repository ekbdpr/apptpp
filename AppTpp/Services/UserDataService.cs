using AppTpp.Model;
using MySqlConnector;
using System.Windows;
using System;
using System.Configuration;

namespace AppTpp.Services
{
    internal class UserDataService
    {
        private static UserDataService instance;

        public static UserDataService Instance
        {
            get
            {
                instance ??= new UserDataService();

                return instance;
            }
        }

        public string CurrentUsername { get; private set; }
        public string CurrentPrivilege { get; private set; }

        public void SetCurrentUser(string username, string privilege)
        {
            CurrentUsername = username;
            CurrentPrivilege = privilege;
        }

        public bool GetUserLoginData(string Username, string Password)
        {
            string connectionString = GetConnectionString();
            var connection = new MySqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    connection.Open();

                    string query = $"SELECT * FROM daftar_user WHERE username = '{Username}' AND password = '{Password}'";

                    using MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        UserModel userModel = new()
                        {
                            Name = reader["nama"].ToString(),
                            Privilege = reader["privilege"].ToString()
                        };

                        SetCurrentUser(userModel.Name, userModel.Privilege);
                    }

                    return reader.HasRows;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }
    }
}
