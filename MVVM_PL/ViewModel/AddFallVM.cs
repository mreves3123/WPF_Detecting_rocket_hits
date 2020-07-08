using MVVM_PL.Commands;
using MVVM_PL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PL.ViewModel
{
   public class AddFallVM:IAddFall, INotifyPropertyChanged
    {
         public AddFallCommand MyComAdd { get; set; }
       // public SearchFileCommand MyComAdd { get; set; }
        public SearchFileCommand MyComSearch { get; set; }
        public View.ISearchFileViewService ViewService { get; set; }
        public FallModel myModel { get; set; }
        public AddFallVM(View.ISearchFileViewService vs)
        {
            myModel = new FallModel();
            // MyComAdd = new AddFallCommand(this);
            MyComAdd = new AddFallCommand(this);
            MyComSearch = new SearchFileCommand(this);
            // MyComSearch = new SearchFCommand(this);
            //MyComSearch = new AddFallCommand(this);
            ViewService = vs; 
        }
        public BE.Fall CurFall
        {
            get
            {
                return myModel.CurFall;
            }
            set
            {
                myModel.CurFall = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddNewFall()
        {
            try {
                //myModel.AddNewRep();
                if ((myModel.CurFall.CityFall == "" | myModel.CurFall.AddressFall == "")&&myModel.CurFall.ImageLocation=="")
                    throw new Exception("Please fill all the fields");
            myModel.MyBL.AddFall(myModel.CurFall);
            myModel = new FallModel();
            OnPropertyChanged("CurFall");
                ViewService.AddSuc();
        }
            catch (Exception e)
            {
                ViewService.ViewErrMsg(e.Message);
            }
}
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public void searchFile()
        {
            //////////////addFall.ImageTextBoxSearch
            ViewService.ImageSearch();
        }
    }
}
