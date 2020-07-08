using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.View
{
   public interface ISignService
    {
        void LogInAnalystic();
        void LogInReporter();
        void FieldIsMissing();
        void WrongPsdName();

    }
}
