using MVVM_PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_PL.Commands
{
    public class RefreshGraphCommand : ICommand
    {
        private IGraphFall CurrentVM;  
        public event EventHandler CanExecuteChanged;
        public RefreshGraphCommand()
        {

        }
        public RefreshGraphCommand(IGraphFall currentVM)
        {
            this.CurrentVM = currentVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CurrentVM.DisFallArg();
        }
    }
}

