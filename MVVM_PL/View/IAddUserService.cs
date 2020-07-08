using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.View
{
    public interface IAddUserService
    {
        void AfterSign(string user, string psd);
        void FieldIsMissing();
        void NameExist();
        void WrongPsd();
    }
}
