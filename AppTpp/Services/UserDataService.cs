using AppTpp.Model;
using MySqlConnector;
using System.Windows;
using System;
using System.Configuration;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace AppTpp.Services
{
    internal class UserDataService
    {
        private static UserDataService? instance;

        public static UserDataService Instance
        {
            get
            {
                instance ??= new UserDataService();

                return instance;
            }
        }

        public string? CurrentUsername { get; private set; }
        public string? CurrentPrivilege { get; private set; }
        public byte[]? CurrentProfileImage { get; private set; }

        public void SetCurrentUser(string? username, string? privilege, byte[]? profileImage)
        {
            CurrentUsername = username;
            CurrentPrivilege = privilege;
            CurrentProfileImage = profileImage;
        }

        private static MySqlConnection OpenConnection()
        {
            string connectionString = GetConnectionString();
            var connection = new MySqlConnection(connectionString);

            connection.Open();
            return connection;
        }

        public bool GetUserLoginData(string? Username, string? Password)
        {
            var connection = OpenConnection();

            try
            {
                string query = "SELECT * FROM daftar_user WHERE username = @Username AND password = @Password";

                using MySqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);

                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UserModel? userModel = new()
                    {
                        Username = reader["username"].ToString(),
                        Name = reader["nama"].ToString(),
                        Privilege = reader["privilege"].ToString(),
                        ProfileImage = !string.IsNullOrEmpty(reader["profile_image"].ToString()) ? (byte[])reader["profile_image"] : null
                    };

                    SetCurrentUser(userModel.Name, userModel.Privilege, userModel.ProfileImage);
                }

                return reader.HasRows;
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

        public void SaveImageToDB(OpenFileDialog openFileDialog)
        {
            var connection = OpenConnection();

            if (openFileDialog.ShowDialog() == true)
                try
                {
                    string filePath = openFileDialog.FileName;
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    string query = "UPDATE daftar_user SET profile_image = @FileData WHERE username = @Username;";

                    using var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FileData", fileBytes);
                    command.Parameters.AddWithValue("@Username", CurrentUsername);

                    command.ExecuteNonQuery();

                    Instance.CurrentProfileImage = fileBytes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
        }

        public static List<UserModel>? GetAllUsers()
        {
            var connection = OpenConnection();

            try
            {
                string query = "SELECT * FROM daftar_user";

                using MySqlCommand command = new(query, connection);

                List<UserModel> userList = new();

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserModel userModel = new()
                    {
                        Nip = Convert.ToInt64(reader["nip"]),
                        Name = reader["nama"].ToString(),
                        Jabatan = reader["jabatan"].ToString(),
                        Username = reader["username"].ToString(),
                        Privilege = reader["privilege"].ToString(),
                        ProfileImage = !string.IsNullOrEmpty(reader["profile_image"].ToString()) ? (byte[])reader["profile_image"] : null
                    };

                    userList.Add(userModel);
                }

                return userList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        private protected static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }
    }
}
