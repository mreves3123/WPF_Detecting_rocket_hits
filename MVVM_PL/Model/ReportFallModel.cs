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
    public  class ReportFallModel: INotifyPropertyChanged
    {
        public ReportFallModel()
        {
            CurRepFall = new ReportFall();
            MyBL = BL.BL.GetBL();


        }

        public ReportFall CurRepFall { get; set; }
        public int Intensity2 { get; set; }
        public int Intensity3 { get; set; }
        public IBL MyBL { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

