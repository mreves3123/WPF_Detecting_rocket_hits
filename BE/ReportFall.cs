
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BE
{
    public class ReportFall
    {
        // public int IdNum
        //{ get
        //    {
        //        idNum++;
        //        return idNum-1; }
        //    set
        //    {
        //        idNum = value;
        //    }

        //}
        //static public int idNum = 0;
        //public int idRep ;
        [Key]
        public int IdNum { get; set; }

        public int FallId { get; set; }

        public DateTime DateRep { get; set; }

        public String NameReporter { get; set; }

        public String Address { get; set; }
        public String City { get; set; }
        public int BoomsN { get; set; }
        public int Intensity { get; set; }

        //public double LongRep { get; set; }
        //public double LatRep { get; set; }

        private Coordinate coordinateR;
        

        public Coordinate CoordinateR
        {
            get { return coordinateR; }
            set { coordinateR = value; }
        }

        public ReportFall(int fallId, DateTime date, String nameReporter, String address, String city, int boomsN, int intensity, Coordinate coordinateR)
        {
         //   idRep = idNum++;
            FallId = fallId;
            DateRep = date;
            NameReporter = nameReporter;
            Address = address;
            City = city;
            BoomsN = boomsN;
            Intensity = intensity;
            CoordinateR = coordinateR;
        }
        public ReportFall(ReportFall rep)
        {
            //idRep = idNum++;
            FallId = rep.FallId;
            DateRep = rep.DateRep;
            NameReporter = rep.NameReporter;
            Address = rep.Address;
            City = rep.City;
            BoomsN = rep.BoomsN;
            Intensity = rep.Intensity;
            CoordinateR = new Coordinate(rep.CoordinateR.Latitude, rep.CoordinateR.Longitude);
        }
        public ReportFall()
        {
            //idRep = idNum++;
            FallId = 0;
            DateRep = DateTime.Now;
            NameReporter = "";
            Address = "";
            BoomsN = 1;
            Intensity = 0;
            CoordinateR = new Coordinate(0, 0);
            City = "";
        }


    }
}
