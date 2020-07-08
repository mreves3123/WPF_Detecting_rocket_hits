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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;
using PL.ViewModel;
using PL.View;
using BE;

namespace WPF_Detecting_rocket_hits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        internal BL.IBL bl;
        internal BE.ReportFall rep = null;
        public MainWindow()
        {
            InitializeComponent();

            this.dateRep.SelectedDate = DateTime.Now.Date;
            this.myTimePicker.Value = DateTime.Now;
          
            //rep = new BE.ReportFall();
            //this.DataContext = rep;
            bl = BL.FactoryBL.GetBL();
        }

        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime theDate = this.dateRep.SelectedDate.Value;
            Coordinate coor = bl.GetCoordinate(this.cityTxt.Text, this.streetTxt.Text);//new Coordinate(5, 4);
            rep = new BE.ReportFall(200, new DateTime(theDate.Year, theDate.Month, theDate.Day, myTimePicker.Value.Value.Hour, myTimePicker.Value.Value.Minute, 0), this.nameTxt.Text, this.streetTxt.Text, this.cityTxt.Text, int.Parse(this.boomsTxt.Text), int.Parse(this.intensityTxt.Text),coor);
            bl.AddReportFall(rep);
            successMsg.Visibility = Visibility.Visible;
            this.myMap1.Center.Latitude = coor.Latitude ;
            this.myMap1.Center.Longitude = coor.Longitude;



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            graphs gWin = new graphs();
            gWin.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddFallWin win = new AddFallWin();
            win.Show();
           // this.Close();
        }
    }
}
