using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Fall
    {
        public int FallId { get; set; }
        public String AddressFall { get; set; }
        private Coordinate coordinateF;
        public String CityFall { get; set; }
        public Coordinate CoordinateF
        {
            get { return coordinateF; }
            set { coordinateF = value; }
        }


        //public double LongFall { get; set; }
        //public double LatFall { get; set; }
        public DateTime DateFall { get; set; }

        private string imageLocation;

        public string ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; }
        }

        public Fall (int fallId, String addressFall,String city, Coordinate coordinateF, DateTime date, String imageLocation)
        {
            FallId = fallId;
            AddressFall = addressFall;
            CityFall = city;
            CoordinateF = coordinateF;
            DateFall = date;
            ImageLocation = imageLocation;
        }

        public Fall()
        {
            FallId = 0;
            AddressFall = "";
            CityFall = "";
            //LongFall = -1;
            //LatFall = -1;
            CoordinateF = new Coordinate(0, 0);
            DateFall = new DateTime();
            DateFall = DateTime.Now;
            ImageLocation = "";
        }
        public Fall(Fall fall)
        {
            FallId = fall.FallId;
            AddressFall = fall.AddressFall;
            CityFall = fall.CityFall;
            //LongFall = -1;
            //LatFall = -1;
            CoordinateF = new Coordinate (fall.CoordinateF.Latitude,fall.CoordinateF.Longitude);
            DateFall = fall.DateFall;
            ImageLocation = fall.ImageLocation;
        }
        public override string ToString()
        {
            return "Fall Id: " + FallId+"\n"+AddressFall+", "+CityFall;
        }
    }
}
