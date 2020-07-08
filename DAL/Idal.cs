using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        void AddReportFall(ReportFall newReport);
        void UpdateReportFall(ReportFall newReport);
        void DelReportFall(ReportFall newReport);
        ReportFall GetReport(DateTime dateRep, String name);
        List<ReportFall> ListReportFalls();

        void AddFall(Fall newFall);
        void UpdateFall(Fall newFall);
        void DelFall(Fall newFall);
        Fall GetFall(int id);
        List<Fall> ListFalls();

        Coordinate GetCoordinate(String city, String Address);

        void AddReporter(Reporter newReporter);
        void AddAnalystic(Analystic newAnalystic);
        bool IsReporter(Reporter reporter);
        bool IsAnalystic(Analystic analystic);
        bool ThereIsUserName(string user);

    }
}
