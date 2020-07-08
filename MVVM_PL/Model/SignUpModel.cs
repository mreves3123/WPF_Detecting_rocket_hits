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
   public class SignUpModel: INotifyPropertyChanged
    {
        public SignUpModel()
        {
            CurReporter = new Reporter();
            MyBL = BL.BL.GetBL();
        }
        public Reporter CurReporter { get; set; }
        public string ConfirmPsd { get; set; }
        public bool Analistic { get; set; }

        public bool Reporter { get; set; }
        public IBL MyBL { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
