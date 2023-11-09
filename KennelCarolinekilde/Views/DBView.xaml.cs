using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KennelCarolinekilde.Views
{
    /// <summary>
    /// Interaction logic for DBView.xaml
    /// </summary>
    public partial class DBView : UserControl
    {
        public DBView()
        {
            InitializeComponent();
        }

        DataTable dataTable;
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == true)
            {
                txtFileName.Text = openFileDialog.FileName;

                using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        //read the excel data and configure to treat the first row as headers
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true //Treat the first row as headers
                            }
                        });

                        if (result.Tables.Count > 0)
                        {
                            dataTable = result.Tables[0]; // Assuming the data is in the first (and only) sheet

                            ExcelFilePresenter.ItemsSource = dataTable.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("No data found in the Excel file.");
                        }
                    }
                }
            }
        }
        
        private void btnUpdateDB_Click(object sender, RoutedEventArgs e)
        {

            // call a method in the ViewModel Layer ---> wich calls a method in Model layer to connect to the DB. 

            string connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true;"; ;

            try
            {
                if (dataTable != null)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        using (SqlCommand command = new SqlCommand("dbo.InsertDogs", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter dogsParamter = command.Parameters.AddWithValue("@Dogs", dataTable);
                            dogsParamter.SqlDbType = SqlDbType.Structured;
                            dogsParamter.TypeName = "dbo.DogType";

                            command.ExecuteNonQuery();

                            MessageBox.Show(" Data Inserted Into the DB");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Data to update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);

            }


        }
    }
}
