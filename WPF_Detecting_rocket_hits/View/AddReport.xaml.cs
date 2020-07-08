using BE;
using BL;
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

namespace PL.View
{
    /// <summary>
    /// Interaction logic for AddReport.xaml
    /// </summary>
    public partial class AddReport : UserControl
    {


        //public ReportFall repInner
        //{
        //    get
        //    { return new BE.ReportFall(200, 
        //                            new DateTime(dateRep.SelectedDate.Value.Year, dateRep.SelectedDate.Value.Month, dateRep.SelectedDate.Value.Day, myTimePicker.Value.Value.Hour, myTimePicker.Value.Value.Minute, 0),
        //                            this.nameTxt.Text, this.streetTxt.Text, 
        //                            this.cityTxt.Text, int.Parse(this.boomsTxt.Text), 
        //                            int.Parse(this.intensityTxt.Text), 
        //                            new Geocoder().Geocode(this.cityTxt.Text, this.streetTxt.Text));
        //    }
        //    set
        //    { }
        //}


        public static readonly DependencyProperty TheTextProperty =
            DependencyProperty.Register("repInner", typeof(ReportFall), typeof(AddReport),
                new FrameworkPropertyMetadata("nothing", FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(StateChangeCallBack),
                    new CoerceValueCallback(FixValueCallBack)));

        private static object FixValueCallBack(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void StateChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddReport temp = d as AddReport;
            if(temp!=null)
            {
                //new BE.ReportFall(200,
                //                    new DateTime(temp.dateRep.SelectedDate.Value.Year, temp.dateRep.SelectedDate.Value.Month, temp.dateRep.SelectedDate.Value.Day, temp.myTimePicker.Value.Value.Hour, temp.myTimePicker.Value.Value.Minute, 0),
                //                    temp.nameTxt.Text, temp.streetTxt.Text,
                //                    temp.cityTxt.Text, int.Parse(temp.boomsTxt.Text),
                //                    int.Parse(temp.intensityTxt.Text),
                //                    new Geocoder().Geocode(temp.cityTxt.Text, temp.streetTxt.Text));
            
            }
        }

        public ReportFall repInner {
            get { return (ReportFall)GetValue(TheTextProperty); }
            set { SetValue(TheTextProperty, value); }
        }
        public AddReport()
        {
            InitializeComponent();
            
        }
    }
}
