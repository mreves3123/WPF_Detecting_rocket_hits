using PL.ViewModel;
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
using System.Windows.Shapes;

namespace PL.View
{
    /// <summary>
    /// Interaction logic for AddFallWin.xaml
    /// </summary>
    public partial class AddFallWin : Window
    {
        private FallViewModel curVm;
        public FallViewModel CurVm { get; set; }

        public AddFallWin()
        {
            InitializeComponent();
            this.DateFall.SelectedDate = DateTime.Now.Date;
            this.hourFall.Value = DateTime.Now;
            CurVm = new FallViewModel();
            /// this.DataContext= CurVm.Fall;
           // CurVm.CurrentModel.AddFall(Fall);
        }
    }
}
