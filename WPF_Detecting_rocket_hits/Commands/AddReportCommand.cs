using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PL.Commands
{
    class AddReportCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public IReportViewModel CurrentVM { get; }

        public AddReportCommand()
        {

        }

        public AddReportCommand(IReportViewModel vm)
        {
            CurrentVM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            MessageBox.Show("jkjhh");
            CurrentVM.AddNewReport();
        }
    }
}
