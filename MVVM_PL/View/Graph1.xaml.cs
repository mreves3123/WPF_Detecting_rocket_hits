using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_PL.View
{
    /// <summary>
    /// Interaction logic for Graph1.xaml
    /// </summary>
    public partial class Graph1 : UserControl,INotifyPropertyChanged,IRefGraphViesService
    {
        public Graph1()
        {
            InitializeComponent();
            CurrentVM = new GraphVM(this);
            //fromDP.SelectedDate = DateTime.Today;
            //toDP.SelectedDate = DateTime.Today;
            //OnPropertyChanged("FromDate");
            //OnPropertyChanged("ToDP");
            // CurrentVM.ViewService = (IAddReportViewService)this;
            // DataContext = CurrentVM;
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                    },
                    //DataLabels = true,
                    //LabelPoint = point =>point.Y
                }
            };

            Labels = new string[]
            {
            //    "1",
            //    "2",
            //    "3",
            //    "4",
            //    "5",
            //    "6",
            //    "7"
            };
            Formatter = value => value+"";
            DataContext = this;
            searchBtn.DataContext = CurrentVM;
            fromDP.DataContext = CurrentVM;
            toDP.DataContext = CurrentVM;
        }
        public GraphVM CurrentVM { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateAllOnClick(object sender, RoutedEventArgs e)
        {

            //foreach (var series in SeriesCollection)
            //{
            //    foreach (var observable in series.Values.Cast<ObservableValue>())
            //    {
            //        observable.Value = r.Next(0, 10);
            //    }
            //}
           
            OnPropertyChanged("SeriesCollection");
            OnPropertyChanged("Labels");
        }

        //private void Chart_OnDataClick(object sender, ChartPoint point)
        //{
        //    //point instance contains many useful information...
        //    //sender is the shape that called the event.

        //    MessageBox.Show("You clicked " + point.X + ", " + point.Y);

        //}
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public void refGraph(string[] labels, double[] values)
        {
            ChartValues<ObservableValue> toSet = new ChartValues<ObservableValue>();
            for (int i = 0; i < values.Length; i++)
            {
                toSet.Add(new ObservableValue(values[i]));
            }
            SeriesCollection = new SeriesCollection
            {
                
                new ColumnSeries
                {
                    Values = toSet,
                    DataLabels = true,
                    LabelPoint = point => ""+point.Y
                }
            };

            Labels = labels;
            OnPropertyChanged("SeriesCollection");
            OnPropertyChanged("Labels");
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Refresh()
        {
            ChartValues<ObservableValue> toSet = new ChartValues<ObservableValue>();
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = toSet,
                    DataLabels = true,
                    LabelPoint = point => ""+point.Y
                }
            };
            Labels = new string[]
           {
           };
            OnPropertyChanged("SeriesCollection");
            OnPropertyChanged("Labels");
            fromDP.Text=DateTime.Now.ToString();
            toDP.Text= DateTime.Now.ToString();
        }
        public void ViewErrMsg(string err)
        {
            errLabel.Content = err;
          
            errLabel.Visibility = Visibility.Visible;
        }

        private void Date_GotFocus(object sender, RoutedEventArgs e)
        {
            errLabel.Visibility = Visibility.Hidden;
        }
    }
}
