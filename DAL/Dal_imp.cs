using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Dal_imp : Idal
    {
        
        public async void AddFall(Fall newFall)
        {
           // if (GetFall(newFall.FallId) != null)
            //    throw new Exception("The fall is already exist");
            //else
                using (var db = new ProjectContext())
                {
                     db.Falls.Add(newFall);
                    await db.SaveChangesAsync();
                }

        }

        public async void AddReportFall(ReportFall newReport)
        {
           // if (GetReport(newReport.DateRep, newReport.NameReporter) != null)
           //     throw new Exception("The fall is already exist");
           // else
           // {
                using (var db = new ProjectContext())
                {
                    db.Reports.Add(newReport);
                    await db.SaveChangesAsync();

                }
           //   }
        }

        public void DelFall(Fall newFall)
        {
            if (GetFall(newFall.FallId) == null)
                throw new Exception("The fall is not exist");
           // else
               // DataSource.Remove(newFall);
        }

        public void DelReportFall(ReportFall newReport)
        {
            if (GetReport(newReport.DateRep, newReport.NameReporter) == null)
                throw new Exception("The fall is not exist");
           //else
             //   DataSource.Remove(newFall);
        }

        public  List<Fall> ListFalls()
        {
            List<Fall> result = new List<Fall>();
            using (var db = new ProjectContext())
            {
                var query = from elem in db.Falls
                            select elem;
                foreach (var item in query)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Fall GetFall(int id)
        {
            using (var db = new ProjectContext())
            {
                var result = db.Falls.SingleOrDefault(f1 => f1.FallId == id);

                if (result == null)
                {
                    return null;

                }
                else
                {
                    return result;
                }
            }
        }

        public ReportFall GetReport(DateTime dateRep, string name)
        {
            using (var db = new ProjectContext())
            {
                var result = db.Reports.SingleOrDefault(r1 => r1.DateRep == dateRep && r1.NameReporter == name);

                if (result == null)
                {
                    return null;

                }
                else
                {
                    return result;
                }
            }
        }

        public List<ReportFall> ListReportFalls()
        {
            List<ReportFall> result = new List<ReportFall>();
            using (var db = new ProjectContext())
            {
                var query = from elem in db.Reports
                            select elem;
                foreach (var item in query)
                {
                    result.Add(item);
                }
            }
            return result;

        }

        public async void UpdateFall(Fall newFall)
        {
            using (var db = new ProjectContext())
            {
                var result = db.Falls.SingleOrDefault(f1 => f1.FallId == newFall.FallId);

                if (result == null)
                {
                    throw new Exception("Fall doesnt exist");

                }
                else
                {
                    result = newFall;
                    await db.SaveChangesAsync();
                }
            }

        }

        public async void UpdateReportFall(ReportFall newReport)
        {
            using (var db = new ProjectContext())
            {
                var result = db.Reports.SingleOrDefault(r1 => r1.DateRep == newReport.DateRep && r1.NameReporter== newReport.NameReporter);

                if (result == null)
                {
                    throw new Exception("Report Fall doesnt exist");

                }
                else
                {
                    result = newReport;
                    await db.SaveChangesAsync();
                }
            }
        }

        public Coordinate GetCoordinate(string city, string Address)
        {
            return new Geocoder().Geocode(city, Address);
        }

        public async void AddReporter(Reporter newReporter)
        {
            // if (GetReport(newReport.DateRep, newReport.NameReporter) != null)
            //     throw new Exception("The fall is already exist");
            // else
            // {
            using (var db = new ProjectContext())
            {
                db.Reporters.Add(newReporter);
                await db.SaveChangesAsync();

            }
            //   }
        }

        public async void AddAnalystic(Analystic newAnalystic)
        {
            // if (GetReport(newReport.DateRep, newReport.NameReporter) != null)
            //     throw new Exception("The fall is already exist");
            // else
            // {
            using (var db = new ProjectContext())
            {
                db.Analystics.Add(newAnalystic);
                await db.SaveChangesAsync();

            }
            //   }
        }
        public bool IsReporter(Reporter reporter)
        {
            using (var db = new ProjectContext())
            {
                var result = db.Reporters.SingleOrDefault(r1 => r1.user == reporter.user&&r1.password== reporter.password);

                if (result == null)
                {
                    return false;

                }
                else
                {
                    //if(reporter.password== result.password)
                    return true;
                    //return false;
                }
            }
        }
        public bool IsAnalystic(Analystic analystic)
        {
            using (var db = new ProjectContext())
            {
                var result = db.Analystics.SingleOrDefault(r1 => r1.user == analystic.user && r1.password == analystic.password);

                if (result == null)
                {
                    return false;

                }
                else
                {
                    //if(reporter.password== result.password)
                    return true;
                    //return false;
                }
            }
        }

        public bool ThereIsUserName(string user)
        {
            using (var db = new ProjectContext())
            {
                var analysticResult = db.Analystics.SingleOrDefault(r1 => r1.user == user );
                var reporterResult = db.Reporters.SingleOrDefault(r1 => r1.user == user);

                if (analysticResult == null&& reporterResult==null)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
        }

    }
}
