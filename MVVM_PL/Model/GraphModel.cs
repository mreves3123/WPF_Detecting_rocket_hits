using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.Model
{
    public class GraphModel
    {
        public IBL MyBL { get; set; }
        public GraphModel()
        {
            MyBL = BL.BL.GetBL();
        }
    }
}
