using KennelCarolinekilde.Models;
using KennelCarolinekilde.ViewModels;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for BreedingView.xaml
    /// </summary>
    public partial class BreedingView : UserControl
    {
        BreedingVM breedingVM = new BreedingVM();
        DogVM dogVM = new DogVM();

        public BreedingView()
        {
            InitializeComponent();
            DataContext = breedingVM;
        }

        private void SearchDogButton_Click(object sender, RoutedEventArgs e)
        {
            string SearchText = SearchDogText.Text;
            Dog dog = breedingVM.GetSingleDog(SearchText);
            SelectedDog.Text = dog.ToString();
        }

        private void SearchPartnerCriteria_Click(object sender, RoutedEventArgs e)
        {
            string AD = PartnerCriteria_AD.Text;
            string HD = PartnerCriteria_HD.Text;
            string HZ = PartnerCriteria_HZ.Text;
            string SP = PartnerCriteria_SP.Text;
            List<string> ColorList = new List<string>();
            if ((bool)SearchPartner_Color_Tiger.IsChecked)
            {
                ColorList.Add("Tg");
            }
            if ((bool)SearchPartner_Color_Red.IsChecked)
            {
                ColorList.Add("Rg");
            }
            if ((bool)SearchPartner_Color_White.IsChecked)
            {
                ColorList.Add("hv");
            }
            string Colors = string.Join("/", ColorList);
            string Age = PartnerCriteria_Age.Text;
            // Getting dogs
            dogVM.GetDogsByCriteria(AD, HD, HZ, SP, Colors, Age);
        }
    }
}
