using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KennelCarolinekilde.Views;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System.Configuration;

namespace KennelCarolinekilde.Models.Repos
{
    public class DogRepo: RepoBase
    {
        public List<Dog> DogList { get; private set; } = new List<Dog>();

        //--------------------Constructor--------------------------------
        public DogRepo() { }

        //--------------------Methods------------------------------------

        //TODO Write logic creating dog 
        public string CreateDog(string pedigreeNr, string name, string father= null, string mother = null, DateOnly dateOfBirth = default(DateOnly), string sex = null, 
            string hdIndex = null, string color = null, bool dead = false, bool breedStatus = false, string image = null, string ownerId = null, string hd = null, string ad = null, string hz = null, string sp = null)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
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
                string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
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
                        cmd.Parameters.Add("@ad", System.Data.SqlDbType.NVarChar).Value = ad;
                        cmd.Parameters.Add("@hd", System.Data.SqlDbType.NVarChar).Value = hd;
                        cmd.Parameters.Add("@hz", System.Data.SqlDbType.NVarChar).Value = hz;
                        cmd.Parameters.Add("@sp", System.Data.SqlDbType.NVarChar).Value = sp;
                        cmd.Parameters.Add("@dateofbirth", System.Data.SqlDbType.NVarChar).Value = dogAgeDate;
                        cmd.Parameters.Add("@sex", System.Data.SqlDbType.NVarChar).Value = 't';


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
    }
}
