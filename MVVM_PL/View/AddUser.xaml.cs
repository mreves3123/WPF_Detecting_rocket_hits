using MVVM_PL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    //public class SignUpConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return values.Clone();
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    /// 

    public partial class AddUser : Window,IHavaPssdService, IAddUserService
    {
        public AddUser()
        {
            InitializeComponent();
            CurVM = new SignUpVM(this,this);
            DataContext = CurVM;
        }
        public SignUpVM CurVM { get; set; }

        public void AfterSign(string user, string psd)
        {
            Sign window = new Sign(psd);
            window.CurVM.UserName = user;
            window.Show();

            //pssBox.password = psd;
            this.Close();
        }

        public string getPsd1()
        {
            return password.Password;
        }

        public string getPsd2()
        {
            return confirmPassword.Password;
        }
        public void FieldIsMissing()
        {
            emptylable.Visibility = Visibility.Visible;
        }
        public void NameExist()
        {
            err2.Visibility = Visibility.Visible;
        }
        public void WrongPsd()
        {
            err3.Visibility = Visibility.Visible;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            emptylable.Visibility = Visibility.Hidden;
            err2.Visibility = Visibility.Hidden;
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            emptylable.Visibility = Visibility.Hidden;
            err3.Visibility = Visibility.Hidden;
        }

        private void ConfirmPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            emptylable.Visibility = Visibility.Hidden;
            err3.Visibility = Visibility.Hidden;
        }

        private void AnalysticCheckBox_GotFocus(object sender, RoutedEventArgs e)
        {
            emptylable.Visibility = Visibility.Hidden;
        }

        private void ReporterCheckBox_GotFocus(object sender, RoutedEventArgs e)
        {
            emptylable.Visibility = Visibility.Hidden;
        }
        //private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    if(((PasswordBox)sender).Password!= password.Password)
        //    password.Password = ((PasswordBox)sender).Password;
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}

