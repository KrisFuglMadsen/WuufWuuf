using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KennelCarolinekilde.Models.Repos
{
    public class DogRepo : RepoBase
    {
        public List<Dog> dogList { get; private set; } = new List<Dog>();

        //--------------------Constructor--------------------------------
        public DogRepo() { }

        //--------------------Methods------------------------------------


        //TODO write the logic for GetListOfDogs for all overloads
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
                    using (SqlCommand cmd = new SqlCommand(GetDogByPedigreeNr, connection))
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
            return dog;
        }


        //TODO write the logic for GetListOfDogs for all overloads
        //public List<Dog> GetListOfDogs(string name, string pedigreeNr) { return null; }

        public List<Dog> GetListOfDogs(string ad, string hd, string hz, string sp, string color, string age, string sex)
        {
            //// We'll append all found dogs to this list
            List<Dog> Dogs = new List<Dog>();
            // Ternary: If the string is empty set is null, otherwise the string value (User input)
            string? hdValue = string.IsNullOrEmpty(hd) ? null : hd;
            string? adValue = string.IsNullOrEmpty(ad) ? null : ad;
            string? hzValue = string.IsNullOrEmpty(hz) ? null : hz;
            string? spValue = string.IsNullOrEmpty(sp) ? null : sp;
            // Subtract age from current year
            int Age = Int32.Parse(age);
            DateOnly subtractYears = DateOnly.FromDateTime(DateTime.Now).AddYears(-Age);
            // Format date and convert to string
            string dogAgeDate = subtractYears.ToString("yyyy/M/dd", CultureInfo.InvariantCulture);

            string GetDogsByCriteriaTest = $"GetDogsByCriteria";
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(GetDogsByCriteriaTest, connection))
                    {
                        // Do not comment this out!!!!!
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@color", System.Data.SqlDbType.NVarChar).Value = color;
                        // Ternary: If the string is empty, set the value as a Database Null. Otherwise use the value
                        cmd.Parameters.Add("@HD", System.Data.SqlDbType.NVarChar).Value = string.IsNullOrEmpty(hd) ? (object)DBNull.Value : hdValue;
                        cmd.Parameters.Add("@AD", System.Data.SqlDbType.NVarChar).Value = string.IsNullOrEmpty(ad) ? (object)DBNull.Value : adValue;
                        cmd.Parameters.Add("@HZ", System.Data.SqlDbType.NVarChar).Value = string.IsNullOrEmpty(hz) ? (object)DBNull.Value : hzValue;
                        cmd.Parameters.Add("@SP", System.Data.SqlDbType.NVarChar).Value = string.IsNullOrEmpty(sp) ? (object)DBNull.Value : spValue;
                        cmd.Parameters.Add("@Sex", System.Data.SqlDbType.NVarChar).Value = sex;
                        cmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.NVarChar).Value = dogAgeDate;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dog dog = new Dog();
                                string name = (string)reader["Name"];
                                string dPedigreeNr = (string)reader["PedigreeNr"];
                                string father = (string)reader["Father"];
                                string mother = (string)reader["Mother"];
                                DateOnly dateOfbirth = DateOnly.FromDateTime((DateTime)reader["DateOfBirth"]);
                                decimal hdIndex = (decimal)reader["HDIndex"];
                                string dSex = (string)reader["Sex"];
                                string dColor = (string)reader["Color"];
                                bool dead = (bool)reader["Dead"];
                                bool breedstatus = (bool)reader["BreedStatus"];
                                string image = (string)reader["Image"];
                                int ownerId = (int)reader["OwnerId"];
                                string dHd = (string)reader["HD"];
                                string dAd = (string)reader["AD"];
                                string dHz = (string)reader["HZ"];
                                string dSp = (string)reader["SP"];

                                dog.UpdateDog(name, dPedigreeNr, dateOfbirth, father, mother, hdIndex, dSex, color, dead, breedstatus, ownerId, image, hd, ad, hz, sp);
                                Dogs.Add(dog);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show(Dogs.ToString());
            return Dogs;
        }




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
                using (connection)
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




        //_______________Dogs Logic_____________________________________
        public string CreateDog(string pedigreeNr, string name, string father = null, string mother = null, DateOnly dateOfBirth = default(DateOnly), string sex = null,
        string hdIndex = null, string color = null, bool dead = false, bool breedStatus = false, string image = null, string ownerId = null, string hd = null,
        string ad = null, string hz = null, string sp = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertDogs", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Create a DataTable to represent the structured parameter (DogType).
                        DataTable dogsTable = new DataTable();
                        dogsTable.Columns.Add("PedigreeNr", typeof(string));
                        dogsTable.Columns.Add("Name", typeof(string));
                        dogsTable.Columns.Add("Father", typeof(string));
                        dogsTable.Columns.Add("Mother", typeof(string));
                        dogsTable.Columns.Add("DateOfBirth", typeof(DateTime));
                        dogsTable.Columns.Add("HDIndex", typeof(string));
                        dogsTable.Columns.Add("Sex", typeof(string));
                        dogsTable.Columns.Add("Color", typeof(string));
                        dogsTable.Columns.Add("Dead", typeof(bool));
                        dogsTable.Columns.Add("BreedStatus", typeof(bool));
                        dogsTable.Columns.Add("Image", typeof(string));
                        dogsTable.Columns.Add("OwnerId", typeof(string));
                        dogsTable.Columns.Add("HD", typeof(string));
                        dogsTable.Columns.Add("AD", typeof(string));
                        dogsTable.Columns.Add("HZ", typeof(string));
                        dogsTable.Columns.Add("SP", typeof(string));

                        // Add a row to the DataTable with the provided data.
                        DataRow dogRow = dogsTable.NewRow();
                        dogRow["PedigreeNr"] = pedigreeNr;
                        dogRow["Name"] = name;
                        dogRow["Father"] = father;
                        dogRow["Mother"] = mother;
                        dogRow["DateOfBirth"] = dateOfBirth.ToString();
                        dogRow["HDIndex"] = hdIndex;
                        dogRow["Sex"] = sex;
                        dogRow["Color"] = color;
                        dogRow["Dead"] = dead;
                        dogRow["BreedStatus"] = breedStatus;
                        dogRow["Image"] = image;
                        dogRow["OwnerId"] = ownerId;
                        dogRow["HD"] = hd;
                        dogRow["AD"] = ad;
                        dogRow["HZ"] = hz;
                        dogRow["SP"] = sp;

                        dogsTable.Rows.Add(dogRow);

                        // Set the parameter for the stored procedure.
                        SqlParameter parameter = command.Parameters.AddWithValue("@Dogs", dogsTable);
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "DogType";

                        // Execute the stored procedure.
                        command.ExecuteNonQuery();
                    }
                }

                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    using (SqlCommand command = new SqlCommand("InsertDogTEST", connection))
                //    {
                //        command.CommandType = CommandType.StoredProcedure;

                //        // Add parameters
                //        command.Parameters.AddWithValue("@PedigreeNr", pedigreeNr);
                //        command.Parameters.AddWithValue("@Name", name);
                //        command.Parameters.AddWithValue("@Father", father);
                //        command.Parameters.AddWithValue("@Mother", mother);
                //        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                //        command.Parameters.AddWithValue("@HDIndex", string.IsNullOrEmpty(hdIndex) ? (object)DBNull.Value : hdIndex);
                //        command.Parameters.AddWithValue("@Sex", sex);
                //        command.Parameters.AddWithValue("@Color", color);
                //        command.Parameters.AddWithValue("@Dead", dead);
                //        command.Parameters.AddWithValue("@BreedStatus", breedStatus);
                //        command.Parameters.AddWithValue("@Image", image);
                //        command.Parameters.AddWithValue("@OwnerId", string.IsNullOrEmpty(ownerId) ? (object)DBNull.Value : int.Parse(ownerId));
                //        command.Parameters.AddWithValue("@HD", hd);
                //        command.Parameters.AddWithValue("@AD", ad);
                //        command.Parameters.AddWithValue("@HZ", hz);
                //        command.Parameters.AddWithValue("@SP", sp);

                //        // Output parameter for getting the result
                //        SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.NVarChar, 255);
                //        resultParam.Direction = ParameterDirection.Output;
                //        command.Parameters.Add(resultParam);

                //        command.ExecuteNonQuery();

                // Retrieve the result from the output parameter
                //    string result = resultParam.Value.ToString();

                //    return result;
                //}
                //}

                return "Dog record inserted successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


        public string DeleteDog(string pedigreeNr)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteDogs", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //parameter for the PedigreeNr.
                        command.Parameters.AddWithValue("@PedigreeNr", pedigreeNr);

                        // Execute the stored procedure to delete the dog record.
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Dog record deleted successfully.";
                        }
                        else
                        {
                            return "Dog record with the specified PedigreeNr not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }



        //-----Get Family tree test

        public List<List<Dog>> GetFamilyTree(string pedigreeNr)
        {
            List<List<Dog>> familyTree = new List<List<Dog>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetFamilyTreeTEST", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@PedigreeNr", SqlDbType.NVarChar, 30) { Value = pedigreeNr });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dog dog = MapReaderToDog(reader);
                            int generation = Convert.ToInt32(reader["Generation"]);

                            // Ensure that the familyTree list has enough capacity
                            while (familyTree.Count <= generation)
                            {
                                familyTree.Add(new List<Dog>());
                            }

                            familyTree[generation].Add(dog);
                        }
                    }
                }
            } 
            return familyTree;
        }
        


        private Dog MapReaderToDog(SqlDataReader reader)
        {
            //return new Dog
            //{
            //    Name = reader["Name"].ToString(),
            //    PedigreeNr = reader["PedigreeNr"].ToString(),
            //    DateOfBirth = DateOnly.FromDateTime((DateTime)reader["DateOfBirth"]),
            //    Father = reader["Father"].ToString(),
            //    Mother = reader["Mother"].ToString(),
            //    HDIndex = Convert.ToDecimal(reader["HDIndex"]),
            //    Sex = reader["Sex"].ToString(),
            //    Color = reader["Color"].ToString(),
            //    Dead = Convert.ToBoolean(reader["Dead"]),
            //    BreedStatus = Convert.ToBoolean(reader["BreedStatus"]),
            //    Owner = new Owner { OwnerId = Convert.ToInt32(reader["OwnerId"]) },
            //    Image = reader["Image"].ToString(),
            //    HD = reader["HD"].ToString(),
            //    AD = reader["AD"].ToString(),
            //    HZ = reader["HZ"].ToString(),
            //    SP = reader["SP"].ToString(),
            //    // Map other properties as needed
            //};

            return new Dog
            {
                Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader["Name"].ToString(),
                PedigreeNr = reader.IsDBNull(reader.GetOrdinal("PedigreeNr")) ? string.Empty : reader["PedigreeNr"].ToString(),
                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth"))
            ? DateOnly.MinValue
            : DateOnly.FromDateTime((DateTime)reader["DateOfBirth"]),
                Father = reader.IsDBNull(reader.GetOrdinal("Father")) ? string.Empty : reader["Father"].ToString(),
                Mother = reader.IsDBNull(reader.GetOrdinal("Mother")) ? string.Empty : reader["Mother"].ToString(),
                HDIndex = reader.IsDBNull(reader.GetOrdinal("HDIndex")) ? 0 : Convert.ToDecimal(reader["HDIndex"]),
                Sex = reader.IsDBNull(reader.GetOrdinal("Sex")) ? string.Empty : reader["Sex"].ToString(),
                Color = reader.IsDBNull(reader.GetOrdinal("Color")) ? string.Empty : reader["Color"].ToString(),
                Dead = reader.IsDBNull(reader.GetOrdinal("Dead")) ? false : Convert.ToBoolean(reader["Dead"]),
                BreedStatus = reader.IsDBNull(reader.GetOrdinal("BreedStatus")) ? false : Convert.ToBoolean(reader["BreedStatus"]),
                Owner = new Owner { OwnerId = reader.IsDBNull(reader.GetOrdinal("OwnerId")) ? 0 : Convert.ToInt32(reader["OwnerId"]) },
                Image = reader.IsDBNull(reader.GetOrdinal("Image")) ? string.Empty : reader["Image"].ToString(),
                HD = reader.IsDBNull(reader.GetOrdinal("HD")) ? string.Empty : reader["HD"].ToString(),
                AD = reader.IsDBNull(reader.GetOrdinal("AD")) ? string.Empty : reader["AD"].ToString(),
                HZ = reader.IsDBNull(reader.GetOrdinal("HZ")) ? string.Empty : reader["HZ"].ToString(),
                SP = reader.IsDBNull(reader.GetOrdinal("SP")) ? string.Empty : reader["SP"].ToString(),
                // ... other properties ...
            };
        }













    }  

}


