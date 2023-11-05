using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            return dog; 
        }


        //TODO write the logic for GetListOfDogs for all overloads
        public List<Dog> GetListOfDogs(string name, string pedigreeNr) { return null; }

        public List<Dog> GetListOfDogs(string ad, string hd, string hz, string sp, string color, string age) 
        {
            List<Dog> Dogs = new List<Dog>();
            //int Age = Int32.Parse(age);
            DateTime ageCalc = DateTime.Now;
            int xYear = ageCalc.Year;
            xYear -= Int32.Parse(age);            
            DateOnly AgeDateOfBirth = new DateOnly(xYear, DateTime.Now.Month, DateTime.Now.Day);
            Debug.WriteLine(AgeDateOfBirth);

            string something = $"{xYear}/01/01";

            string GetDogsByCriteriaTest = $"GetDogsByCriteriaTest";
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(GetDogsByCriteriaTest, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar).Value = color;
                        //cmd.Parameters.Add("@AD", System.Data.SqlDbType.NVarChar).Value = ad;
                        //cmd.Parameters.Add("@HD", System.Data.SqlDbType.NVarChar).Value = hd;
                        //cmd.Parameters.Add("@HZ", System.Data.SqlDbType.NVarChar).Value = hz;
                        //cmd.Parameters.Add("@SP", System.Data.SqlDbType.NVarChar).Value = sp;
                        ////cmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.NVarChar).Value = AgeDateOfBirth.ToString();
                        //cmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.NVarChar).Value = something;
                        //cmd.Parameters.Add("@Sex", System.Data.SqlDbType.NVarChar).Value = 'T';

                        cmd.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar).Value = color;
                        cmd.Parameters.Add("@AD", System.Data.SqlDbType.NVarChar).Value = '0';
                        cmd.Parameters.Add("@HD", System.Data.SqlDbType.NVarChar).Value = 'B';
                        cmd.Parameters.Add("@HZ", System.Data.SqlDbType.NVarChar).Value = '0';
                        cmd.Parameters.Add("@SP", System.Data.SqlDbType.NVarChar).Value = '4';
                        cmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.NVarChar).Value = "2005/11/06";
                        cmd.Parameters.Add("@Sex", System.Data.SqlDbType.NVarChar).Value = 'T';

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
                                string sex = (string)reader["Sex"];
                                string dColor = (string)reader["Color"];
                                bool dead = (bool)reader["Dead"];
                                bool breedstatus = (bool)reader["BreedStatus"];
                                string image = (string)reader["Image"];
                                int ownerId = (int)reader["OwnerId"];
                                string dHd = (string)reader["HD"];
                                string dAd = (string)reader["AD"];
                                string dHz = (string)reader["HZ"];
                                string dSp = (string)reader["SP"];

                                dog.UpdateDog(name, dPedigreeNr, dateOfbirth, father, mother, hdIndex, sex, color, dead, breedstatus, ownerId, image, hd, ad, hz, sp);
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
