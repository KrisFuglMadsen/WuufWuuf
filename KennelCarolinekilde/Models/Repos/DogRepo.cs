using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KennelCarolinekilde.Models.Repos
{
    public class DogRepo: RepoBase
    {
        public List<Dog> dogList { get; private set; } = new List<Dog>();

        //--------------------Constructor--------------------------------
        public DogRepo() { }

        //--------------------Methods------------------------------------

        //TODO write the logic for GetSingleDog
        public Dog GetSingleDog(string name, string pedigreeNr) { return null; }
        public Dog GetSingleDog(string pedigreeNr) 
        {
            Dog dog = new Dog();
            string GetDogByPedigreeNr = $"GetDogByPedigreeNr";
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                try
                {
                    connection.Open();
                    using(SqlCommand cmd = new SqlCommand(GetDogByPedigreeNr, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@PedigreeNr", System.Data.SqlDbType.NVarChar).Value = pedigreeNr;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = (string)reader["Name"];
                                string dPedigreeNr = (string)reader["PedigreeNr"];
                                string father = (string)reader["Father"];
                                string mother = (string)reader["Mother"];
                                //DateTime dateTime = (Date)reader["DateOfBirth"];
                                DateOnly dateOfbirth = DateOnly.FromDateTime((DateTime)reader["DateOfBirth"]);
                                decimal hdIndex = (decimal)reader["HDIndex"];
                                string sex = (string)reader["Sex"];
                                string color = (string)reader["Color"];
                                bool dead = (bool)reader["Dead"];
                                bool breedstatus = (bool)reader["BreedStatus"];
                                string image = (string)reader["Image"];
                                int ownerId = (int)reader["OwnerId"];
                                string hd = (string)reader["HD"];
                                string ad = (string)reader["AD"];
                                string hz = (string)reader["HZ"];
                                string sp = (string)reader["SP"];

                                dog.UpdateDog(name, pedigreeNr, dateOfbirth, father, mother, hdIndex, sex, color, dead, breedstatus, ownerId, image, hd, ad, hz, sp);


                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show(dog.ToString());
            return dog; 
        }


        //TODO write the logic for GetListOfDogs for all overloads
        public List<Dog> GetListOfDogs(string name, string pedigreeNr) { return null; }
        public List<Dog> GetListOfDogs(List<string> health, List<string> color, int age) { return null; }


        //----------------Update DB logic--------------------------------
        public DataTable LoadDataFromExcel(string filePath)
        {
            DataTable dataTable = null;
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Read the excel data and configure to treat the first row as headers
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // Treat the first row as headers
                        }
                    });

                    if (result.Tables.Count > 0)
                    {
                        dataTable = result.Tables[0]; // Assuming the data is in the first (and only) sheet
                    }
                }
            }
            return dataTable;
        }

        public void UpdateDatabase(DataTable dataTable)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using(connection)
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.InsertDogs", connection)) // use the SP we created in our DB design.
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter dogsParameter = command.Parameters.AddWithValue("@Dogs", dataTable);
                        dogsParameter.SqlDbType = SqlDbType.Structured;
                        dogsParameter.TypeName = "dbo.DogType";  //use the custom definde TVP we createde in oure DB design.

                        command.ExecuteNonQuery();

                        MessageBox.Show("Data Inserted Into The DB");
                        
                    }
               
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }



    }
}
