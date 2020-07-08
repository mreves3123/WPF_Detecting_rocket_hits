using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Win32;
using MVVM_PL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Maps.MapControl.WPF;
using BE;
namespace MVVM_PL.View
{
    /// <summary>
    /// Interaction logic for AnalisticW.xaml
    /// </summary>
    public partial class AnalisticW : Window//, INotifyPropertyChanged
    {
        public AnalisticW()
        {
            InitializeComponent();
        }

       // public event PropertyChangedEventHandler PropertyChanged;

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {

            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            UserGrid.Width = 880;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            UserGrid.Width = 1020;
        }

        private void AddItem_Selected(object sender, RoutedEventArgs e)
        {
            if (UserGrid.Children.OfType<TextBlock>().FirstOrDefault() != null)
                UserGrid.Children.Remove(nameTextBlock);
            addUC.Refresh();
            addUC.Visibility = Visibility.Visible;
            assesUC.Visibility = Visibility.Collapsed;
            searchUC.Visibility = Visibility.Collapsed;
        }

        private void SearchItem_Selected(object sender, RoutedEventArgs e)
        {
            if (UserGrid.Children.OfType<TextBlock>().FirstOrDefault() != null)
                UserGrid.Children.Remove(nameTextBlock);
            addUC.Visibility = Visibility.Collapsed;
            assesUC.Visibility = Visibility.Collapsed;
           
            searchUC.Visibility = Visibility.Visible;
            searchUC.Refresh();
        }

        private void AssessmentItem_Selected(object sender, RoutedEventArgs e)
        {
            if (UserGrid.Children.OfType<TextBlock>().FirstOrDefault() != null)
                UserGrid.Children.Remove(nameTextBlock);
            addUC.Visibility = Visibility.Collapsed;
            assesUC.Refresh();
            assesUC.Visibility = Visibility.Visible;
            searchUC.Visibility = Visibility.Collapsed;

            //    ///////////////////////
            //    /
            //    assesUC.SeriesCollection = new SeriesCollection
            //    {
            //        new ColumnSeries
            //        {
            //            the distanc
            //            Values = new ChartValues<ObservableValue>
            //            {
            //                new ObservableValue(1),
            //                new ObservableValue(1),
            //                new ObservableValue(1),
            //                new ObservableValue(1),
            //                new ObservableValue(1),
            //                new ObservableValue(1),
            //                new ObservableValue(1),
            //            },
            //            DataLabels = false,
            //            LabelPoint = point => point.X + "K ," + point.Y
            //        }
            //    };
            //    falls id
            //    assesUC.Labels = new[]
            //    {
            //        "1",
            //        "2",
            //        "3",
            //        "4",
            //        "5",
            //        "6",
            //        "7"
            //    };


            //    assesUC.Formatter = value => value + "m ";
            //    OnPropertyChanged("SeriesCollection");

            //    DataContext = this;
            //}

            //private void OnPropertyChanged(string propertyName)
            //{
            //    var handler = PropertyChanged;
            //    if (handler != null)
            //    {
            //        handler(this, new PropertyChangedEventArgs(propertyName));

            //    }
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sign window = new Sign();
            window.Show();
            this.Close();
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}