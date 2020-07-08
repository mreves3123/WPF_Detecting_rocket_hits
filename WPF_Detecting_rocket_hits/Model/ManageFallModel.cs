using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace PL.Model
{
    public class ManageFallModel
    {
        public IBL Bl { get; set; }

        public Fall Fall { get; set; }

        public ManageFallModel()
        {
       //     Fall = new BE.Fall(200,"llll","kkkk",new Coordinate(32,32),new DateTime(1998,2,2), "image/logo.jpg");
            Bl = BL.FactoryBL.GetBL();
            //Falls = new List<Fall>(Bl.FallList());
        }

        public void AddFall()
        {
           Bl.AddFall(Fall);
        }


    }
}
