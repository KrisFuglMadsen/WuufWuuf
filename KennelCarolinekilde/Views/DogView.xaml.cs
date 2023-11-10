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
    /// Interaction logic for DogView.xaml
    /// </summary>
    public partial class DogView : UserControl
    {
        private DogVM dogvm = new DogVM();
        public DogView()
        {
            InitializeComponent();
        }

        private void Add_Dog_btn(object sender, RoutedEventArgs e)
        {
            string pedigreeNr = PedigreeNrTXB.Text;
            string name = NameTXB.Text;
            string mother = MotherTXB.Text;
            string father = FatherTXB.Text;
            DateOnly dateOfBirth = DateOnly.Parse(BirthDayTXB.Text);
            string sex = SexTXB.Text;
            string dhIndex = HDIndexTXB.Text;
            string color = ColorTXB.Text;
            bool dead= false;
            bool breedStatus = false;
            string d = DeadTXB.Text;
            if (d == "1")
            {
                dead = true;
            }

            string b = BreedStatusTXB.Text;
            if (b == "1")
            {
                breedStatus = true;
            }

            string image = ImageTXB.Text;
            string ownerId = OwnerTXB.Text;
            string hd = HDTXB.Text;
            string ad = ADTXB.Text;
            string hz = HZ_TXB.Text;
            string sp = SP_TXB.Text;

            MessageBox.Show( dogvm.CreateDog(pedigreeNr, name, father, mother, dateOfBirth, sex, dhIndex, color, dead, breedStatus, image, ownerId, hd, ad, hz, sp));
            //DogVM dogvm = new DogVM();


        }

        private void Delete_Dog_Btn_Click(object sender, RoutedEventArgs e)
        {
            DogRepo dogRepo = new DogRepo();
            MessageBox.Show(dogRepo.DeleteDog(PedigreeNrTXB.Text));
        }
    }
}
