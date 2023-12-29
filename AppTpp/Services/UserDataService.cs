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

        public void SetCurrentUser(string? name, string? username, string? privilege)
        {
            CurrentName = name;
            CurrentUsername = username;
            CurrentPrivilege = privilege;
        }

        public void SetCurrentUserPhoto(byte[]? profileImage)
        {
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
                string query = "SELECT * FROM daftar_user WHERE Username = @Username AND Password = @Password";

                using MySqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);

                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UserModel? userModel = new()
                    {
                        Username = reader["Username"].ToString(),
                        Name = reader["Nama"].ToString(),
                        Privilege = reader["Privilege"].ToString(),
                    };

                    SetCurrentUser(userModel.Name, userModel.Username, userModel.Privilege);
                }

                return reader.HasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool GetUserPhoto(string? Username)
        {
            using var connection = OpenConnection();

            try
            {
                string query = "SELECT * FROM user_photo WHERE Username = @Username";

                using MySqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@Username", Username);

                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UserModel? userModel = new()
                    {
                        ProfileImage = !string.IsNullOrEmpty(reader["Profile_image"].ToString()) ? (byte[])reader["Profile_image"] : null
                    };

                    SetCurrentUserPhoto(userModel.ProfileImage);
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

                    string query = "UPDATE user_photo SET Profile_image = @FileData WHERE Username = @Username;";

                    using var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FileData", fileBytes);
                    command.Parameters.AddWithValue("@Username", CurrentUsername);

                    command.ExecuteNonQuery();

                    Instance.CurrentProfileImage = fileBytes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
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
                        Nip = Convert.ToInt64(reader["Nip"]),
                        Name = reader["Nama"].ToString(),
                        Jabatan = reader["Jabatan"].ToString(),
                        Username = reader["Username"].ToString(),
                        Privilege = reader["Privilege"].ToString(),
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
                string query = "INSERT INTO daftar_user (Nip, Nama, Jabatan, Username, Password, Privilege) " +
                               "VALUES (@Nip, @Nama, @Jabatan, @Username, @Password, @Privilege)";

                using MySqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Nip", nip);
                command.Parameters.AddWithValue("@Nama", name);
                command.Parameters.AddWithValue("@Jabatan", jabatan);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Privilege", privilege);

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
