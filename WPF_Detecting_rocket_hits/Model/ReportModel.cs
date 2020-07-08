using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model
{
    class ReportModel
    {
        public ReportModel()
        {
            CurRepFall = new ReportFall();
            Bl = BL.FactoryBL.GetBL();


        }

        public ReportFall CurRepFall { get;  set; }

        public IBL Bl { get; set; }
    }
}
