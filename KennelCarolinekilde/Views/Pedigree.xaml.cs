using KennelCarolinekilde.Models;
using KennelCarolinekilde.Models.Repos;
using KennelCarolinekilde.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Pedigree.xaml
    /// </summary>
    public partial class Pedigree : UserControl
    {
        public Pedigree()
        {
            InitializeComponent();
        }

        private void ChosenDogButton_Click(object sender, RoutedEventArgs e)
        {
            DogRepo dogRepo = new DogRepo();

            //To show information about the chosen dog.

            string SearchText = ChosenDogText.Text;
            Dog dog = dogRepo.GetSingleDog(SearchText);
            // To upper so we can easier compare in SearchPartnerCriteria_Click
            ChosenDogCard.Text = dog.ToString();

            // Mapping the list of list wiht dogs
            List<Dog> generation_0 = new List<Dog>();
            List<Dog> generation_1 = new List<Dog>();
            List<Dog> generation_2 = new List<Dog>();
            List<Dog> generation_3 = new List<Dog>();
            List<Dog> generation_4 = new List<Dog>();
            List<Dog> generation_5 = new List<Dog>();
            List<Dog> generation_6 = new List<Dog>();
            List<Dog> generation_7 = new List<Dog>();
            List<Dog> generation_8 = new List<Dog>();

            //----- Names display in generations card--------------
            string oneGenUp = "";
            string twoGenUp = "";
            string threeGenUp = "";
            string fourGenUP = "";
            string fiveGenUP = "";
            string sixGenUp = "";
            string sevenGenUp = "";
            string eightGenUp = "";

            string pedigreeNr = ChosenDogText.Text;

            List<List<Dog>> allLists = dogRepo.GetFamilyTree(pedigreeNr);

            int x = 0;
            foreach (List<Dog> dogsList in allLists)
            {
                switch (x)
                {
                    case 0:
                        generation_0 = dogsList;
                        break;
                    case 1:
                        generation_1 = dogsList;
                        break;
                    case 2:
                        generation_2 = dogsList;
                        break;
                    case 3:
                        generation_3 = dogsList;
                        break;
                    case 4:
                        generation_4 = dogsList;
                        break;
                    case 5:
                        generation_5 = dogsList;
                        break;
                    case 6:
                        generation_6 = dogsList;
                        break;
                    case 7:
                        generation_7 = dogsList;
                        break;
                    case 8:
                        generation_8 = dogsList;
                        break;
                    default:
                        // Handle unexpected case if needed
                        break;
                }
                x++;
            }

            foreach (Dog d in generation_2)
            {
                oneGenUp += d.Name + "/ ";
                
            }

            foreach (Dog d in generation_3)
            {
                twoGenUp += d.Name + "/ ";

            }

            foreach (Dog d in generation_4)
            {
                threeGenUp += d.Name + "/ ";

            }

            foreach (Dog d in generation_5)
            {
                fourGenUP += d.Name + "/ ";
            }

            foreach (Dog d in generation_6)
            {
                fiveGenUP += d.Name + "/ ";
            }

            foreach (Dog d in generation_7)
            {
                sixGenUp += d.Name + "/ ";
            }

            OneGenerationUp.Text = oneGenUp;
            TwoGenerationUp.Text = twoGenUp;
            ThreeGenerationUp.Text = threeGenUp;
            FourGenerationUp.Text = fourGenUP;
            FiveGenerationUp.Text = fiveGenUP;
            SixGenerationUp.Text = sixGenUp;
            SevenGenerationUp.Text = sevenGenUp;
            EightGenerationUp.Text = eightGenUp;


            //---------- for the easy solution with datagrid------------------------------- 
            Generation_1.ItemsSource = generation_1;
            Generation_2.ItemsSource = generation_2;
            Generation_3.ItemsSource = generation_3;
            Generation_4.ItemsSource = generation_4;
            Generation_5.ItemsSource = generation_5;
            Generation_6.ItemsSource = generation_6;
            Generation_7.ItemsSource = generation_7;
            Generation_8.ItemsSource = generation_8;

        }

    }
}
