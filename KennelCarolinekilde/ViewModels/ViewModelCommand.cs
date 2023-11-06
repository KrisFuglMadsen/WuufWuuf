using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KennelCarolinekilde.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        //fields
        private readonly Action<object> _executeAction;         //the action delegate is used so we can incapsulate a methoed an pass it as a parameter.
        private readonly Predicate<object> _canExecuteAction;   //the predicate delegat is used to determind if the action can be executede or not.

        //Constructors
        public ViewModelCommand(Action<object> executeAction)   // It is not all actions there needs to be validaded so we creat another Ctor with only one parameter
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }
        //Events
        public event EventHandler CanExecuteChanged             //we use the CommanManger keyword, this checks if the value of the CanExecuteAction is changed.
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //Methods

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
