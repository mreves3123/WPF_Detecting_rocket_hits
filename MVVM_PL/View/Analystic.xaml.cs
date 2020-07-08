using MVVM_PL.ViewModel;
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

namespace MVVM_PL.View
{
    /// <summary>
    /// Interaction logic for Analystic.xaml
    /// </summary>
    public partial class Analystic : Window
    {
        public AddFallVM CurrentVM { get; set; }
        public Analystic()
        {
            InitializeComponent();
            CurrentVM = new AddFallVM(null);
            DataContext = CurrentVM;
        }
    }
}
