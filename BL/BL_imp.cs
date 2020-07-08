using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Device.Location;
using Accord.MachineLearning;

namespace BL
{
    public class BL_imp : IBL
    {
        Idal myDal;

        public BL_imp()
        {
            myDal = Dal.get_dal();
        }

        public void AddFall(Fall newFall)
        {
            Coordinate tmp = new Coordinate();
            if (newFall.DateFall > DateTime.Now)
                throw new Exception("The date is not valid");
            if (newFall.ImageLocation == "")
                tmp = new Geocoder().Geocode(newFall.AddressFall, newFall.CityFall);
            else// enter location according to image
            {
                tmp = new Geocoder().getImageCoordinate(newFall.ImageLocation);
            }
            newFall.CoordinateF = new Coordinate(tmp.Latitude, tmp.Longitude);
            if (newFall.CoordinateF.Latitude == 0 && newFall.CoordinateF.Longitude == 0)
                throw new Exception("The address is not correct");
            myDal.AddFall(newFall);
        }

        public void AddReportFall(ReportFall newReportFall)
        {
            if (newReportFall.DateRep > DateTime.Now)
                throw new Exception("The date is not valid");
            if (newReportFall.BoomsN <= 0)
                throw new Exception("The number is not valid");
            var x = newReportFall.Intensity;
            if (newReportFall.Intensity < 1 || newReportFall.Intensity > 10)
                throw new Exception("The Intensity is not valid");
            //צריך להכניס את הנקודות ציון
            Coordinate tmp = new Geocoder().Geocode(newReportFall.Address, newReportFall.City);
            newReportFall.CoordinateR = new Coordinate(tmp.Latitude,tmp.Longitude);
            if (newReportFall.CoordinateR.Latitude==0&& newReportFall.CoordinateR.Longitude==0)
                throw new Exception("The address is not correct");
            myDal.AddReportFall(newReportFall);
        }

        public void DelFall(Fall newReport)
        {
            throw new NotImplementedException();
        }

        public void DelReportFall(ReportFall newReport)
        {
            throw new NotImplementedException();
        }


        public void UpdateFall(Fall newFall)
        {
            if (newFall.DateFall > DateTime.Now)
                throw new Exception("The date is not valid");
            myDal.UpdateFall(newFall);
        }

        public void UpdateReportFall(ReportFall newReport)
        {
            if (newReport.DateRep > DateTime.Now)
                throw new Exception("The date is not valid");
            if (newReport.BoomsN <= 0)
                throw new Exception("The number is not valid");
            if (newReport.Intensity < 1 || newReport.Intensity > 10)
                throw new Exception("The Intensity is not valid");
            myDal.UpdateReportFall(newReport);
        }

       public List<Fall> FallAcordDate(DateTime date)
        {
            List<Fall> myList = new List<Fall>();
            var result = from item in myDal.ListFalls()
                         where item.DateFall.Date == date.Date
                         select item;
            foreach (var item in result)
            {
                myList.Add(item);
            }
            return myList;
        }
        public List<Fall> FallsBetweenDates(DateTime dateFrom,DateTime dateTo)
        {
            if (DateTime.Compare(dateFrom, dateTo) > 0)
                throw new Exception("The date FROM is bigger than date TO");
            List<Fall> myList = new List<Fall>();
            foreach (var item in myDal.ListFalls())
            {
                if(DateTime.Compare(item.DateFall.Date, dateFrom) >= 0 && (DateTime.Compare(item.DateFall.Date, dateTo) <= 0))
                    myList.Add(item);
            }
            //var result = from item in myDal.ListFalls()
            //             where (DateTime.Compare( item.DateFall, dateFrom)>=0 && (DateTime.Compare(item.DateFall, dateTo) <= 0))
            //             select item;
            //foreach (var item in result)
            //{
            //    myList.Add(item);
            //}
            return myList;
        }

        public List<Fall> FallAcordDateTenMin(DateTime date)
        {
            List<Fall> myList = new List<Fall>();
            //var result = from item in myDal.ListFalls()
            //                 // where (item.DateFall>= date) &&(item.DateFall <= date.AddMinutes(10)) 
            //                 where DateTime.Compare(item.DateFall, date) >=0 && DateTime.Compare(item.DateFall, date.AddMinutes(10)) <= 0
            //             select item;
            foreach (var item in myDal.ListFalls())
            {
                if (DateTime.Compare(item.DateFall, date) >= 0 && DateTime.Compare(item.DateFall, date.AddMinutes(10)) <= 0)
                    myList.Add(new Fall(item));
            }
            //foreach (var item in result)
            //{
            //    myList.Add(item);
            //}
            return myList;
        }
        public List<Fall> FallAcordCity(string city)
        {
            List<Fall> myList = new List<Fall>();
            var result = from item in myDal.ListFalls()
                         where item.CityFall == city////????
                         select item;
            foreach (var item in result)
            {
                myList.Add(item);
            }
            return myList;

        }

        public List<ReportFall> ReportFallAcordDate(DateTime date)
        {
            List<ReportFall> myList = new List<ReportFall>();
            var result = from item in myDal.ListReportFalls()
                         where item.DateRep.Date == date.Date
                         select item;
            foreach (var item in result)
            {
                myList.Add(item);
            }
            return myList;
        }

        public List<ReportFall> ReportFallAcordDateTenMin(DateTime fromDate, DateTime toDate)
        {
            List<ReportFall> myList = new List<ReportFall>();
            //var result = from item in myDal.ListReportFalls()
            //             where (item.DateRep >= date) && (item.DateRep<= date.AddMinutes(10))
            //             select item;
            //foreach (var item in result)
            //{
            //    myList.Add(item);
            //}
            foreach (var item in myDal.ListReportFalls())
            {
                if (DateTime.Compare(item.DateRep, fromDate) >= 0 && DateTime.Compare(item.DateRep, toDate.AddMinutes(10)) <= 0)
                    myList.Add(new ReportFall(item));
            }
            return myList;
        }
        public  List<ReportFall> ReportFallAcordCity(string city)
        {
            List<ReportFall> myList = new List<ReportFall>();
            var result = from item in myDal.ListReportFalls()
                         where item.City == city///???
                         select item;
            foreach (var item in result)
            {
                myList.Add(item);
            }
            return myList;
        }
        #region distance


        public double DistanceTo(Coordinate baseCoordinates, Coordinate targetCoordinates)
        {
            return DistanceTo(new GeoCoordinate( baseCoordinates.Latitude, baseCoordinates.Longitude),new GeoCoordinate(targetCoordinates.Latitude, targetCoordinates.Longitude), UnitOfLength.Kilometers);
        }

        public double DistanceTo(GeoCoordinate baseCoordinates, GeoCoordinate targetCoordinates, UnitOfLength unitOfLength)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unitOfLength.ConvertFromMiles(dist);
        }

        public List<Fall> FallList()
        {
            return myDal.ListFalls();
        }

        public List<ReportFall> ReportList()
        {
            return myDal.ListReportFalls();
        }

       
        public class UnitOfLength
        {
            public static UnitOfLength Kilometers = new UnitOfLength(1.609344);
            public static UnitOfLength NauticalMiles = new UnitOfLength(0.8684);
            public static UnitOfLength Miles = new UnitOfLength(1);

            private readonly double _fromMilesFactor;

            private UnitOfLength(double fromMilesFactor)
            {
                _fromMilesFactor = fromMilesFactor;
            }

            public double ConvertFromMiles(double input)
            {
                return input * _fromMilesFactor;
            }
        }
        #endregion
        public Coordinate GetCoordinate(string city, string Address)
        {
            return myDal.GetCoordinate(city, Address);
        }

        //weight-intensity
        //data-the places of the reports(lat,long)
        // מחזיר ממוצעים של לונג ולט לפי קבוצות, כמספר הקבוצות שהוזן.
        public double[][] returnAvgPerGroup(double[][] data, double[] weight, int numK)
        {
            Accord.Math.Random.Generator.Seed = 0;
            // Create a new K-Means algorithm
            KMeans kmeans = new KMeans(k: numK);
            // Compute and retrieve the data centroids
            var clusters = kmeans.Learn(data, weight);
            // var clusters2=kmeans.Compute(observations,new double[2,7,3,4,7,3])
            // Use the centroids to parition all the data
            return clusters.Centroids;
        }
        public Coordinate[] CoorReturnAvg(Coordinate[] CoorData, double[] weight, int numK)
        {
            Coordinate[] result = new Coordinate[numK];
            double[][] toSend = new double[CoorData.Length][];
            for (int i = 0; i < CoorData.Length; i++)
            {
                toSend[i] = new double[2];
                toSend[i][0] = CoorData[i].Latitude;
                toSend[i][1] = CoorData[i].Longitude;
            }
            double[][] res = returnAvgPerGroup(toSend, weight,  numK);
            for (int i = 0; i < res.Length; i++)
            {
                result[i] = new Coordinate(res[i][0], res[i][1]);
            }
            return result;
        }
        //מחזיר מערך שמחלק כל נקודה לאזור
        public int[] returnPointPerGroup(double[][] data, double[] weight, int numK)
        {
            Accord.Math.Random.Generator.Seed = 0;
            // Create a new K-Means algorithm
            KMeans kmeans = new KMeans(k: numK);
            // Compute and retrieve the data centroids
            var clusters = kmeans.Learn(data, weight);
            // var clusters2=kmeans.Compute(observations,new double[2,7,3,4,7,3])
            // Use the centroids to parition all the data
            int[] labels = clusters.Decide(data);
            return labels;
        }

        public int[] CoorReturnPointPerGroup(Coordinate[] CoorData, double[] weight, int numK)
        {
            double[][] toSend = new double[CoorData.Length][];
            for (int i = 0; i < CoorData.Length; i++)
            {
                toSend[i][0] = CoorData[i].Latitude;
                toSend[i][1] = CoorData[i].Longitude;
            }
            return returnPointPerGroup(toSend, weight, numK);
        }
        
        //נקבל מערך נפילות ונחזיר את הנפילה האחרונה שקרתה
        public Fall lastFall(List<Fall> falls)
        {
            Fall maxFall = new Fall(falls[0]);
            foreach (var item in falls)
            {
                if (item.DateFall > maxFall.DateFall)
                    maxFall = new Fall(item);
            }
            return maxFall;
        }

        //מקבלת נפילה ומחזירה את הקורדינטה שחושבה על פי KMEAS
        public Coordinate coordAcordFall(Fall theFall)
        {
            List<Fall> fallLst = FallAcordDateTenMin(theFall.DateFall);
            List<ReportFall> repLst = ReportFallAcordDateTenMin(theFall.DateFall,(lastFall(fallLst)).DateFall);
            
            int k = fallLst.Count;
            if (repLst.Count > 0 && fallLst.Count > 0 && repLst.Count >= fallLst.Count)
            {
                //מה ממוצעי הקורדינאטות של הנפעלות בעשר דקות
                Coordinate[] toSend = new Coordinate[repLst.Count];
                double[] inten = new double[repLst.Count];
                for (int i = 0; i < repLst.Count; i++)
                {
                    toSend[i] = repLst[i].CoordinateR;
                    inten[i] = repLst[i].Intensity;
                }
                Coordinate[] CoorData = CoorReturnAvg(toSend, inten, k);
                double min = DistanceTo(theFall.CoordinateF, CoorData[0]);
                int indexMin = 0;
                for (int i = 1; i < k; i++)
                {
                    double dist = DistanceTo(theFall.CoordinateF, CoorData[i]);
                    if (min > dist)
                    {
                        min = dist;
                        indexMin = i;
                    }
                }
                return CoorData[indexMin];
            }
            else
                return null;
        }
        //עבור נפילה, ההפרש בין הקורדי האמיתית למה שחושב
        public double disAcordFall(Fall theFall)
        {
            Coordinate c = coordAcordFall(theFall);
            if(c!=null)
                 return DistanceTo(c,theFall.CoordinateF);
            return -1;
        }
        public bool IsReporter(Reporter reporter)
        {
           return myDal.IsReporter(reporter);
        }
       public bool IsAnalystic(Analystic analystic)
        {
            return myDal.IsAnalystic(analystic);
        }

        public bool ThereIsUserName(string user)
        {
            return myDal.ThereIsUserName(user);
        }

        public void AddReporter(Reporter newReporter)
        {
             myDal.AddReporter( newReporter);
        }

        public void AddAnalystic(Analystic newAnalystic)
        {
             myDal.AddAnalystic(newAnalystic);
        }
    }
}
