using MVVM_PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_PL.Commands
{
    public class SearchFileCommand : ICommand
    {
        private IAddFall CurrentVM;
        public Action _execute;
        public event EventHandler _CanExecuteChanged;
        public SearchFileCommand()
        {
        }
        public SearchFileCommand(IAddFall vm)
        {
            this.CurrentVM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CurrentVM.searchFile();
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
