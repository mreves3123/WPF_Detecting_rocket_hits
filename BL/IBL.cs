using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Device.Location;
namespace BL
{
   public interface IBL
    {
        void AddReportFall(ReportFall newReport);
        void UpdateReportFall(ReportFall newReport);
        void DelReportFall(ReportFall newReport);


        void AddFall(Fall newReport);
        void UpdateFall(Fall newReport);
        void DelFall(Fall newReport);

        List<Fall> FallList();
        List<ReportFall> ReportList();
        List<Fall> FallAcordDate(DateTime date);
        List<ReportFall> ReportFallAcordCity(string city);
        List<ReportFall> ReportFallAcordDate(DateTime date);
        List<Fall> FallAcordCity(string city);
        double DistanceTo(Coordinate baseCoordinates, Coordinate targetCoordinates);
        List<Fall> FallsBetweenDates(DateTime dateFrom, DateTime dateTo);
        Coordinate GetCoordinate(String city, String Address);
        Coordinate coordAcordFall(Fall theFall);
        double disAcordFall(Fall theFall);


        void AddReporter(Reporter newReporter);
        void AddAnalystic(Analystic newAnalystic);

        bool IsReporter(Reporter reorter);
        bool IsAnalystic(Analystic analystic);
        bool ThereIsUserName(string user);
    }
}
