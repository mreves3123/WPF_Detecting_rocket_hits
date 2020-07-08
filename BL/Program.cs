using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate coo = new Geocoder().Geocode("Bnei Brak", "Shadal 2");
            Console.WriteLine(coo.Latitude + " " + coo.Longitude);

            Console.WriteLine(new Geocoder().GetDistanceBetweenPoints(coo, new Coordinate(32, 12)));
            Console.ReadLine();
        }
    }
}
