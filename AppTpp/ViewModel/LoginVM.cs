using AppTpp.Model;
using AppTpp.Services;
using AppTpp.Utilities;
using MySqlConnector;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppTpp.ViewModel
{
    class LoginVM : ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginVM()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object obj)
        {
            if (isValidUser())
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            } else
            {
                MessageBox.Show("Username / Password anda salah");
            }
        }

        private bool isValidUser()
        {
            string connectionString = GetConnectionString();
            var connection = new MySqlConnection(connectionString);

            try
            {
                using(connection)
                {
                    connection.Open();

                    string query = $"SELECT * FROM daftar_user WHERE username = '{Username}' AND password = '{Password}'";

                    using(MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                UserModel userModel = new UserModel
                                {
                                    Name = reader["nama"].ToString(),
                                    Privilege = reader["privilege"].ToString()
                                };

                                UserDataService.Instance.SetCurrentUser(userModel.Name, userModel.Privilege);
                            }

                            return reader.HasRows;
                        }
                    }                                        
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }
    }
}
