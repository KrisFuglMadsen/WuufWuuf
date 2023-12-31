﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KennelCarolinekilde.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        //Properties
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

        //--> Commands
        public ICommand ShowDBViewCommand { get; }

        //Constructor
        public MainViewModel()
        {
            //Initialize commands
            ShowDBViewCommand = new ViewModelCommand(ExecuteShowDBViewCommand);

            //Default view
            
        }

        //Methods
        private void ExecuteShowDBViewCommand(object obj)
        {
            CurrentChildView = new DBViewModel();
            Caption = "Database";
            Icon = IconChar.Database;
        }
    }
}
