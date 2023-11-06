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

namespace KennelCarolinekilde.Models.Repos
{
    public class DogRepo: RepoBase
    {
        public List<Dog> DogList { get; private set; } = new List<Dog>();

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
            return dog; 
        }


        //TODO write the logic for GetListOfDogs for all overloads
        public List<Dog> GetListOfDogs(string name, string pedigreeNr) { return null; }

        public List<Dog> GetListOfDogs(string ad, string hd, string hz, string sp, string color, string age, string sex) 
        {           
            // We'll append all found dogs to this list
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
            
            Debug.WriteLine(dogAgeDate);
            Debug.WriteLine(sex);

            string GetDogsByCriteriaTest = $"GetDogsByCriteria";
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(GetDogsByCriteriaTest, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // For developing purposes: Finds a Dog
                        //cmd.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar).Value = "White";
                        //cmd.Parameters.Add("@HD", System.Data.SqlDbType.NVarChar).Value = 'C';
                        //cmd.Parameters.Add("@AD", System.Data.SqlDbType.NVarChar).Value = 'B';
                        //cmd.Parameters.Add("@HZ", System.Data.SqlDbType.NVarChar).Value = 'A';
                        //cmd.Parameters.Add("@SP", System.Data.SqlDbType.NVarChar).Value = 'C';
                        //cmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.NVarChar).Value = "2019/01/01";
                        //cmd.Parameters.Add("@Sex", System.Data.SqlDbType.NVarChar).Value = 'T';
                        
                        cmd.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar).Value = color;
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
            return Dogs; 
        }
    }
}
