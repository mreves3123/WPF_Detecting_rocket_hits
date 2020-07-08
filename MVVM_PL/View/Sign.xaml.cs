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
    /// Interaction logic for Sign.xaml
    /// </summary>
    public partial class Sign : Window,ISignService
    {
        public SignVM CurVM { get; set; }
        public Sign()
        {
            InitializeComponent();
            CurVM = new SignVM();
            CurVM.ViewService=(ISignService)this;
            DataContext = CurVM;
        }
        public Sign(string psd)
        {
            InitializeComponent();
            CurVM = new SignVM();
            CurVM.ViewService = (ISignService)this;
            DataContext = CurVM;
            pssBox.Password = psd;
        }

        private void TextBlock_MouseDown( object sender, MouseButtonEventArgs e)
        {
            AddUser window = new AddUser();
            window.Show();
            this.Close();
        }

        public void LogInReporter()
        {
            //MessageBox.Show("Reporting successfully added!");
            Report window = new Report();
            window.Show();
            this.Close();
        }

        public void LogInAnalystic()
        {
            //MessageBox.Show("Reporting successfully added!");
            AnalisticW window = new AnalisticW();
            window.Show();
            this.Close();
        }
        //Label x:Name="emptylable"  Content="Please fill all the fields" HorizontalAlignment="Left" Margin="92,123,0,0" VerticalAlignment="Top" Foreground="#DDFF0909" FontFamily="Bradley Hand ITC" FontWeight="Bold" FontSize="16" Visibility="Hidden"/>
        //<Label x:Name="wfillds"  Content="Wrong value in field " HorizontalAlignment="Left" Margin="92,112,0,0" VerticalAlignment="Top" Foreground="#DDFF0909" FontFamily="Bradley Hand ITC" FontWeight="Bold" FontSize="16" Visibility="Hidden"/>
        public void FieldIsMissing()
        {
            emptylable.Visibility = Visibility.Visible;
        }
        public void WrongPsdName()
        {
            wfillds.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            wfillds.Visibility = Visibility.Hidden;
            emptylable.Visibility = Visibility.Hidden;
        }

        private void PssBox_GotFocus(object sender, RoutedEventArgs e)
        {
            wfillds.Visibility = Visibility.Hidden;
            emptylable.Visibility = Visibility.Hidden;
        }

        private void RoleComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            wfillds.Visibility = Visibility.Hidden;
            emptylable.Visibility = Visibility.Hidden;
        }
    }
}
