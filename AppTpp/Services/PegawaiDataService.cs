using AppTpp.Exceptions;
using AppTpp.MVVM.Model;
using MySqlConnector;
using OfficeOpenXml;
using System.Collections.Generic;
using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace AppTpp.Services
{
    internal class PegawaiDataService
    {
        private static PegawaiDataService _instance = new();
        public static PegawaiDataService Instance
        {
            get
            {
                _instance ??= new PegawaiDataService();

                return _instance;
            }
        }

        private static MySqlConnection OpenConnection()
        {
            string connectionString = GetConnectionString();
            var connection = new MySqlConnection(connectionString);

            connection.Open();
            return connection;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }

        public static void ImportExcelToDatabase(string filePath, string tahun, string bulan)
        {
            using var package = new ExcelPackage(new FileInfo(filePath!));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var worksheet = package.Workbook.Worksheets[0];
            int startRow = 2;

            using var connection = OpenConnection();

            try
            {
                for (int row = startRow; row <= worksheet.Dimension.Rows; row++)
                {
                    string tglGaji = $"{tahun}-{bulan}-01".Trim();
                    string nip = worksheet.Cells[row, 1].Value?.ToString()?.Trim() ?? string.Empty;
                    string nama = worksheet.Cells[row, 2].Value?.ToString()?.Trim() ?? string.Empty;
                    string kdSatker = worksheet.Cells[row, 3].Value?.ToString()?.Trim() ?? string.Empty;
                    string norek = worksheet.Cells[row, 4].Value?.ToString()?.Trim() ?? string.Empty;
                    string kdPangkat = worksheet.Cells[row, 5].Value?.ToString()?.Trim() ?? string.Empty;
                    string piwp1 = worksheet.Cells[row, 6].Value?.ToString()?.Trim() ?? string.Empty;
                    string nmSkpd = worksheet.Cells[row, 7].Value?.ToString()?.Trim() ?? string.Empty;
                    string paguTpp = worksheet.Cells[row, 8].Value?.ToString()?.Trim() ?? string.Empty;

                    string query = $"INSERT INTO data_pegawai (Tgl_Gaji, Nip, Nama, Kd_Satker, Norek, Kd_Pangkat, Piwp1, Nm_Skpd, Pagu_Tpp) " +
                                    "VALUES (@Tgl_Gaji, @Nip, @Nama, @Kd_Satker, @Norek, @Kd_Pangkat, @Piwp1, @Nm_Skpd, @Pagu_Tpp);";

                    if (IsNipExist(nip, tglGaji))
                    {
                        throw new DuplicateDataException("❌ Terdapat NIP yang terduplikasi / telah ada di database pada bulan yang sama !");
                    }

                    using MySqlCommand command = new(query, connection);

                    command.Parameters.AddWithValue("@Tgl_Gaji", tglGaji);
                    command.Parameters.AddWithValue("@Nip", nip);
                    command.Parameters.AddWithValue("@Nama", nama);
                    command.Parameters.AddWithValue("@Kd_Satker", kdSatker);
                    command.Parameters.AddWithValue("@Norek", norek);
                    command.Parameters.AddWithValue("@Kd_Pangkat", kdPangkat);
                    command.Parameters.AddWithValue("@Piwp1", piwp1);
                    command.Parameters.AddWithValue("@Nm_Skpd", nmSkpd);
                    command.Parameters.AddWithValue("@Pagu_Tpp", paguTpp);

                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private static bool IsNipExist(string nip, string tglGaji)
        {
            using var connection = OpenConnection();

            try
            {
                string query = "SELECT COUNT(*) FROM data_pegawai WHERE Nip = @Nip AND Tgl_Gaji = @Tgl_Gaji";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nip", nip);
                command.Parameters.AddWithValue("@Tgl_Gaji", tglGaji);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public static List<PegawaiModel> GetAllDataPegawai(string tahun, string bulan)
        {
            using var connection = OpenConnection();

            try
            {
                string query = $"SELECT Tgl_Gaji, Nip, Nama, Kd_Satker, Norek, Kd_Pangkat, Piwp1, Nm_Skpd, Pagu_Tpp FROM data_pegawai WHERE Tgl_Gaji = @Tgl_Gaji ORDER BY Nama ASC";
                string tglGaji = $"{tahun}-{bulan}-01".Trim();

                using MySqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@Tgl_Gaji", tglGaji);

                List<PegawaiModel> pegawaiList = new();

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    PegawaiModel pegawaiModel = new()
                    {
                        TglGaji = reader["Tgl_Gaji"].ToString(),
                        Nip = reader["Nip"].ToString(),
                        Name = reader["Nama"].ToString(),
                        KdSatker = reader["Kd_Satker"].ToString(),
                        Norek = reader["Norek"].ToString(),
                        KdPangkat = reader["Kd_Pangkat"].ToString(),
                        Piwp1 = reader["Piwp1"].ToString(),
                        NamaSkpd = reader["Nm_Skpd"].ToString(),
                        PaguTpp = Convert.ToInt32(reader["Pagu_Tpp"]),
                    };

                    pegawaiList.Add(pegawaiModel);
                }

                return pegawaiList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new();
            }
        }
    }
}
