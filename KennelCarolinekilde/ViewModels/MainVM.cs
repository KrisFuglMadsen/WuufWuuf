using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KennelCarolinekilde.ViewModels
{
    public class MainVM: ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView 
        {
            get
            {
                return _currentChildView;
            }
            set 
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        
        public string Caption 
        {
            get
            {
             return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));

            }
        }
        // Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowBreedingViewCommand { get; }
        public ICommand ShowDogViewCommand {  get; }

        public MainVM()
        {
            // Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowBreedingViewCommand = new ViewModelCommand(ExecuteShowBreedingViewCommand);
            ShowDogViewCommand = new ViewModelCommand(ExecuteShowDogViewCommand);

            // Default view
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeVM();
            Caption = "Hjem";
            Icon = IconChar.Home;
        }

        private void ExecuteShowBreedingViewCommand(object obj)
        {
            CurrentChildView = new BreedingVM();
            Caption = "Avlspartner";
            Icon = IconChar.Heart;
        }
        private void ExecuteShowDogViewCommand(object obj)
        {
            CurrentChildView = new DogVM();
            Caption = "Hunde";
            Icon = IconChar.Dog;
        }
    }
}
