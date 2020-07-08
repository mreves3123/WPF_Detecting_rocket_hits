using MVVM_PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM_PL.Commands
{
    public class LogInCommand: ICommand
    {
        public ISign CurVM;
        public Action _execute;

        public event EventHandler _CanExecuteChanged;

        public LogInCommand(ISign curVM)
        {
            CurVM = curVM;
        }
        public LogInCommand()
        {
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            CurVM.CheckUser(password);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void RaiseCanExecuteChanged()
        {
            if (_CanExecuteChanged != null)
                _CanExecuteChanged(this, new EventArgs());

        }
    }
}
