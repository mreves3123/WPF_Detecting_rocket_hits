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
using Microsoft.Maps.MapControl.WPF;
using BE;
namespace MVVM_PL.View
{
    /// <summary>
    /// Interaction logic for SearchWithMap.xaml
    /// </summary>
    public partial class SearchWithMap : UserControl
    {
        public SearchWithMap()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString();
        }

     
        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            while (map.mapUC.Children.Count > 0)
                map.mapUC.Children.RemoveAt(0);
            map.mapUC.Center = new Location(32.067547, 34.836051);
            map.mapUC.ZoomLevel = 8.5;
            DateTime theDate = date.SelectedDate.Value;
            listView.ItemsSource = BL.BL.GetBL().FallAcordDate(theDate);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Fall fall = new Fall((Fall)(listView.SelectedItem));
                // map.pin.Location =new Microsoft.Maps.MapControl.WPF.Location(fall.CoordinateF.Latitude,fall.CoordinateF.Longitude);
                Pushpin pushpin = new Pushpin();
                Pushpin pushpin1 = new Pushpin();
                pushpin.Location = new Location(fall.CoordinateF.Latitude, fall.CoordinateF.Longitude);
                pushpin.Background = new SolidColorBrush(Color.FromArgb(100, 100, 100, 100));

                Coordinate coor = new Coordinate(BL.BL.GetBL().coordAcordFall(fall));
                pushpin1.Location = new Location(coor.Latitude, coor.Longitude);

                while (map.mapUC.Children.Count > 0)
                    map.mapUC.Children.RemoveAt(0);
                map.mapUC.Children.Add(pushpin);
                map.mapUC.Children.Add(pushpin1);
                map.mapUC.SetView(new Location(fall.CoordinateF.Latitude, fall.CoordinateF.Longitude), 15);
            }

        }
        public void Refresh()
        {
            date.Text = DateTime.Now.ToString();
            //listView.ItemsSource = null;
            while (map.mapUC.Children.Count > 0)
                map.mapUC.Children.RemoveAt(0);
            map.mapUC.Center = new Location(32.067547, 34.836051);
            map.mapUC.ZoomLevel = 8.5;


        }




        // listView.ItemsSource=BL.BL.GetBL().FallAcordDate((DatePicker)sender)

    }
}
