using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using PL.Model;
using System.ComponentModel;

namespace PL.ViewModel
{
    public class FallViewModel:INotifyPropertyChanged
    {
        //comands
        public ManageFallModel CurrentModel { get; set; }

        public Fall Fall { get; set; }

        public FallViewModel()
        {
            //comand- new
            CurrentModel = new ManageFallModel();
            Fall = CurrentModel.Fall;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
