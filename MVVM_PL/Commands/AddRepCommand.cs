using MVVM_PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_PL.Commands
{
    public class AddRepCommand : ICommand
    {
        private IAddRep CurrentVM;
        public Action _execute;
        //private Func<bool> _canExecute;
        public event EventHandler _CanExecuteChanged;
        public AddRepCommand()
        {

        }
        public AddRepCommand(IAddRep currentVM)
        {
            this.CurrentVM = currentVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CurrentVM.AddNewRep();
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
