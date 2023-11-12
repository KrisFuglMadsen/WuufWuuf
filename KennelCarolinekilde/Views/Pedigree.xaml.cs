using KennelCarolinekilde.Models;
using KennelCarolinekilde.Models.Repos;
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

            List<Dog> generation_1 = new List<Dog>();
            List<Dog> generation_2 = new List<Dog>();
            List<Dog> generation_3 = new List<Dog>();
            List<Dog> generation_4 = new List<Dog>();
            List<Dog> generation_5 = new List<Dog>();
            List<Dog> generation_6 = new List<Dog>();
            List<Dog> generation_7 = new List<Dog>();
            List<Dog> generation_8 = new List<Dog>();

            string pedigreeNr = ChosenDogText.Text;

            List<List<Dog>> allLists = dogRepo.GetFamilyTree(pedigreeNr);

            int x = 0;
            foreach (List<Dog> dogsList in allLists)
            {
                switch (x)
                {
                    case 0:
                        generation_1 = dogsList;
                        break;
                    case 1:
                        generation_2 = dogsList;
                        break;
                    case 2:
                        generation_3 = dogsList;
                        break;
                    case 3:
                        generation_4 = dogsList;
                        break;
                    case 4:
                        generation_5 = dogsList;
                        break;
                    case 5:
                        generation_6 = dogsList;
                        break;
                    case 6:
                        generation_7 = dogsList;
                        break;
                    case 7:
                        generation_8 = dogsList;
                        break;
                    default:
                        // Handle unexpected case if needed
                        break;
                }
                x++;
            }
            
            Generations.ItemsSource = generation_4;
        }

    }
}
