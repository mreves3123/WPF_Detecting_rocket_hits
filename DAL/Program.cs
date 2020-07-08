using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProjectContext())
            {
                Coordinate coor = new Coordinate(5, 4);

                var f=new ReportFall(65, new DateTime(1998, 3, 3), "kkk", "sss", "sss", 2, 2, coor);
                var f2 = new Reporter("mayshar5","1234");
                var f3 = new Analystic("sara5","12345");
                //var f = new ReportFall();// (600,new DateTime(1998,6,6),"name","street","city",2,2,3,3);
                Console.WriteLine("start");
                db.Reports.Add(f);
                db.Reporters.Add(f2);
                db.Analystics.Add(f3);
                Console.WriteLine("mid");
                db.SaveChanges();
                Console.WriteLine("finish");
                //updating
                //var result = db.Falls.SingleOrDefault(f1 => f1.FallId == 3);
                //if (result != null)
                //{
                //    Console.WriteLine("if_start");
                //    result.LatFall = 100;
                //    db.SaveChanges();
                //    Console.WriteLine("if_end");
                //}
                //var f4 = new ReportFall(65, new DateTime(2019, 9, 3,7,32,0), "sari", "Ahad Ha'Am St 3", "Ramat Gan", 1, 2, coor);
                //var f5 = new Fall(3, "Matania 19 - 11", "Ramat Gan", Coordinate coordinateF, DateTime date, String imageLocation));

            }




        }


    }
}

