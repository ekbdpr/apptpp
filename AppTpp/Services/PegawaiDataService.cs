using AppTpp.Exceptions;
using AppTpp.MVVM.Model;
using MySqlConnector;
using OfficeOpenXml;
using System.Collections.Generic;
using System;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace AppTpp.Services
{
    internal class PegawaiDataService
    {
        private static PegawaiDataService? _instance;
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

        public static void ImportExcelToDatabase(string? filePath)
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
                    string? tglGaji = worksheet.Cells[row, 1].Value?.ToString();
                    string? nip = worksheet.Cells[row, 2].Value?.ToString();
                    string? nama = worksheet.Cells[row, 3].Value?.ToString();
                    string? kdSatker = worksheet.Cells[row, 4].Value?.ToString();
                    string? norek = worksheet.Cells[row, 5].Value?.ToString();
                    string? kdPangkat = worksheet.Cells[row, 6].Value?.ToString();
                    string? piwp1 = worksheet.Cells[row, 7].Value?.ToString();
                    string? nmSkpd = worksheet.Cells[row, 8].Value?.ToString();
                    string? paguTpp = worksheet.Cells[row, 9].Value?.ToString();

                    string query = $"INSERT INTO data_pegawai (Tgl_Gaji, Nip, Nama, Kd_Satker, Norek, Kd_Pangkat, Piwp1, Nm_Skpd, Pagu_Tpp) " +
                                    "VALUES (@Tgl_Gaji, @Nip, @Nama, @Kd_Satker, @Norek, @Kd_Pangkat, @Piwp1, @Nm_Skpd, @Pagu_Tpp);";

                    using var command = new MySqlCommand(query, connection);

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
                if (ex.Number == 1062)
                {
                    throw new DuplicateDataException("❌ Terdapat NIP yang terduplikasi / telah ada di database !");
                }
                else
                {
                    MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        public static List<PegawaiModel> GetAllDataPegawai()
        {
            using var connection = OpenConnection();

            try
            {
                string query = "SELECT Tgl_Gaji, Nip, Nama, Kd_Satker, Norek, Kd_Pangkat, Piwp1, Nm_Skpd, Pagu_Tpp FROM data_pegawai ORDER BY Nama ASC";

                using MySqlCommand command = new(query, connection);

                List<PegawaiModel> pegawaiList = new();

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    PegawaiModel pegawaiModel = new()
                    {
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
                return null!;
            }
        }
    }
}
