using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.View
{
    public interface IRefGraphViesService
    {
        void refGraph(string[] labels, double[] values );
        void ViewErrMsg(string err);
    }
}
