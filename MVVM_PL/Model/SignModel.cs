using BE;
using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.Model
{
   public class SignModel: INotifyPropertyChanged
    {

        public SignModel()
        {
            CurReporter = new Reporter();
            MyBL = BL.BL.GetBL();
        }
        public Reporter CurReporter { get; set; }

        public IBL MyBL { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
