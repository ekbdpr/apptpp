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

        public string? CurrentName { get; private set; }
        public string? CurrentUsername { get; private set; }
        public string? CurrentPrivilege { get; private set; }
        public byte[]? CurrentProfileImage { get; private set; }

        public void SetCurrentUser(string? name, string? username, string? privilege, byte[]? profileImage)
        {
            CurrentName = name;
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
            using var connection = OpenConnection();

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

                    SetCurrentUser(userModel.Name, userModel.Username, userModel.Privilege, userModel.ProfileImage);
                }

                return reader.HasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public void SaveImageToDB(OpenFileDialog openFileDialog)
        {
            using var connection = OpenConnection();

            if (openFileDialog.ShowDialog() == true)
            {
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

                    MessageBox.Show(CurrentUsername, CurrentProfileImage?.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public static List<UserModel>? GetAllUsers()
        {
            using var connection = OpenConnection();

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
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public static void InsertNewUser(string? nip, string? name, string? jabatan, string? username, string? password, string? privilege)
        {
            using var connection = OpenConnection();

            try
            {
                string query = "INSERT INTO daftar_user (nip, nama, jabatan, username, password, privilege, profile_image) " +
                               "VALUES (@nip, @nama, @jabatan, @username, @password, @privilege, NULL)";

                using MySqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@nip", nip);
                command.Parameters.AddWithValue("@nama", name);
                command.Parameters.AddWithValue("@jabatan", jabatan);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@privilege", privilege);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }
    }
}
