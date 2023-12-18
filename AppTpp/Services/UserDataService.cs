using AppTpp.Model;
using MySqlConnector;
using System.Windows;
using System;
using System.Configuration;
using Microsoft.Win32;
using System.IO;

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

        public int CurrentIdUser { get; private set; }
        public string CurrentUsername { get; private set; }
        public string CurrentPrivilege { get; private set; }
        public byte[] CurrentProfileImage { get; private set; }

        public void SetCurrentUser(int idUser, string username, string privilege, byte[] profileImage)
        {
            CurrentIdUser = idUser;
            CurrentUsername = username;
            CurrentPrivilege = privilege;
            CurrentProfileImage = profileImage;
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

                    string query = "SELECT * FROM daftar_user WHERE username = @Username AND password = @Password";

                    using MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    using MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UserModel userModel = new()
                        {
                            Id = Convert.ToInt32(reader["id_user"]),
                            Name = reader["nama"].ToString(),
                            Privilege = reader["privilege"].ToString(),
                            ProfileImage = (byte[])reader["profile_image"]
                        };

                        SetCurrentUser(userModel.Id, userModel.Name, userModel.Privilege, userModel.ProfileImage);
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

        public void SaveFileToDb(OpenFileDialog openFileDialog)
        {
            string connectionString = GetConnectionString();
            var connection = new MySqlConnection(connectionString);

            if (openFileDialog.ShowDialog() == true)
                try
                {
                    connection.Open();

                    string filePath = openFileDialog.FileName;
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    string query = "UPDATE daftar_user SET profile_image = @FileData WHERE id_user = @CurrentIdUser;";

                    using var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FileData", fileBytes);
                    command.Parameters.AddWithValue("@CurrentIdUser", CurrentIdUser);

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

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }
    }
}
