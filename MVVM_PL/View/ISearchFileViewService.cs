using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.View
{
    public interface ISearchFileViewService
    {
        void ImageSearch();
        void ViewErrMsg(string err);
        void AddSuc();
    }
}
