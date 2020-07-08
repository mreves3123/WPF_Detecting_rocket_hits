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
using System.Windows.Threading;

namespace MVVM_PL.View
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window, IAddReportViewService
    {

  
        public ReportVM CurrentVM { get; set; }
        public Report()
        {
            InitializeComponent();
            CurrentVM = new ReportVM();
            CurrentVM.ViewService = (IAddReportViewService)this;
            DataContext = CurrentVM;

        }
        private void boomControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            int x;
            bool try1=int.TryParse(boomsRepFall.Text, out x);
            if (try1 == true)
            {
                var val = int.Parse(boomsRepFall.Text);
                if (val > 0 && val < 3)
                    if (val == 1)
                    {
                        this.Label1.Visibility = Visibility.Visible;
                        this.slider1.Visibility = Visibility.Visible;
                        this.Label2.Visibility = Visibility.Hidden;
                        this.slider2.Visibility = Visibility.Hidden;
                        this.Label3.Visibility = Visibility.Hidden;
                        this.slider3.Visibility = Visibility.Hidden;
                    }
                if (val == 2)
                {
                    this.Label1.Visibility = Visibility.Visible;
                    this.slider1.Visibility = Visibility.Visible;
                    this.Label2.Visibility = Visibility.Visible;
                    this.slider2.Visibility = Visibility.Visible;
                    this.Label3.Visibility = Visibility.Hidden;
                    this.slider3.Visibility = Visibility.Hidden;
                }
                if (val == 3)
                {
                    this.Label1.Visibility = Visibility.Visible;
                    this.slider1.Visibility = Visibility.Visible;
                    this.Label2.Visibility = Visibility.Visible;
                    this.slider2.Visibility = Visibility.Visible;
                    this.Label3.Visibility = Visibility.Visible;
                    this.slider3.Visibility = Visibility.Visible;
                }
            }
            else
                boomsRepFall.Text = "1";

        }

        //public void AddRepMessage()
        //{
        //    // MessageBox.Show("Reporting successfully added!");
        //    //tbkLabel.Text = "two seconds delay";
        //    succLabel.Visibility = Visibility.Visible;
        //    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3)};
        //    timer.Start();
        //    timer.Tick += (sender, args) =>
        //    {
        //        timer.Stop();
        //    };
        //    succLabel.Visibility = Visibility.Hidden;

        //}
        public async void AddRepMessage()
        {
            succLabel.Visibility = Visibility.Visible;
            await Task.Delay(5000);
            succLabel.Visibility = Visibility.Hidden;
        }
        public void CleanFieldes()
        {
            nameTextBox.Clear();
        }
        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            Sign window = new Sign();
            window.Show();
            this.Close();
        }
        public void ViewErrMsg(string err)
        {
            errLabel.Content = err;
            if (cityTextBox1.Text == "")
                cityTextBox1.BorderBrush = new SolidColorBrush(Colors.Red);
            if(nameTextBox.Text=="")
                nameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            if (streetTextBox2.Text == "")
                streetTextBox2.BorderBrush = new SolidColorBrush(Colors.Red);
            if(err== "The address is not correct")
            {
                cityTextBox1.BorderBrush = new SolidColorBrush(Colors.Red);
                cityTextBox1.Text = "";
                streetTextBox2.BorderBrush = new SolidColorBrush(Colors.Red);
                streetTextBox2.Text = "";
            }
            errLabel.Visibility = Visibility.Visible;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (errLabel.Content.ToString()=="Please fill all the fields")
            errLabel.Visibility = Visibility.Hidden;
            if (errLabel.Content.ToString() == "The address is not correct")
                errLabel.Visibility = Visibility.Hidden;
          

        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cityTextBox1.Text != "")
                cityTextBox1.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x7D, 0x8B));
            if (nameTextBox.Text != "")
                nameTextBox.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x7D, 0x8B));
            if (streetTextBox2.Text != "")
                streetTextBox2.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x7D, 0x8B));

        }
        private void DateTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (errLabel.Content.ToString() == "Please fill all the fields"|| errLabel.Content.ToString() == "The date is not valid")
                errLabel.Visibility = Visibility.Hidden;
        }
        private void Slider_GotFocus(object sender, RoutedEventArgs e)
        {
            if (errLabel.Content.ToString() == "The Intensity is not valid")
                errLabel.Visibility = Visibility.Hidden;
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        //The date is not valid
    }
}
