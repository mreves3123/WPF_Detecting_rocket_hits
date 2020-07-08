using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.Model
{
    public class FallModel
    {
        public FallModel()
        {
            CurFall = new Fall();
            MyBL = BL.BL.GetBL();
        }
        public Fall CurFall { get; set; }

    public IBL MyBL { get; set; }
    }
}
