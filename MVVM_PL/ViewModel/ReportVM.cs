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
    public class ReportVM : IAddRep, INotifyPropertyChanged
    {
        public AddRepCommand MyCom { get; set; }
        public ReportFallModel myModel { get; set; }
        public View.IAddReportViewService ViewService { get; set; }
        public int idRepFall
        {
            set
            {
                myModel.CurRepFall.FallId = value;
            }
        }
        public string nameRepFall
        {
            set
            {
                myModel.CurRepFall.NameReporter = value;
            }
        }
        public string addressRepFall
        {
            set
            {
                myModel.CurRepFall.Address = value;
            }
        }
        public string cityRepFall
        {
            set
            {
                myModel.CurRepFall.City = value;
            }
        }
        public DateTime dateRepFall
        {
            set
            {
                myModel.CurRepFall.DateRep = value;
            }
        }
        public int boomsRepFall
        {
            set
            {
                myModel.CurRepFall.BoomsN = value;
            }
        }
        public int IntensityRepFall
        {
            set
            {
                myModel.CurRepFall.Intensity = value;
            }
        }
        public int Intensity2RepFall
        {
            set
            {
                myModel.Intensity2 = value;
            }
            get { return myModel.Intensity2; }
        }
        public int Intensity3RepFall
        {
            set
            {
                myModel.Intensity3 = value;
            }
            get { return myModel.Intensity3; }
        }
        public BE.ReportFall CurRep
        {
            get
            {
                return myModel.CurRepFall;
            }
            set
            {
                myModel.CurRepFall = value;
            }
        }
        public ReportVM()
        {
            myModel = new ReportFallModel();
            MyCom = new AddRepCommand(this);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        // PropertyChanged+=
        // myModel.MyBL.AddReportFall(myModel.CurRepFall);
        public void AddNewRep()
        {
            try
            {
                if (myModel.CurRepFall.NameReporter == "" || myModel.CurRepFall.Address == "" || myModel.CurRepFall.City == "" ||
                    myModel.CurRepFall.DateRep.ToString().Equals(""))
                    throw new Exception("Please fill all the fields");
                //myModel.AddNewRep();
                //intensity1
                myModel.MyBL.AddReportFall(myModel.CurRepFall);
                if (CurRep.BoomsN >= 2)
                {
                    //myModel.CurRepFall.IdNum = myModel.CurRepFall.IdNum;
                    //intensity 2
                    myModel.CurRepFall.Intensity = myModel.Intensity2;
                    myModel.MyBL.AddReportFall(myModel.CurRepFall);
                    if (CurRep.BoomsN == 3)
                    {
                        //intensity 3
                        // myModel.CurRepFall.idRep = myModel.CurRepFall.IdNum;
                        myModel.CurRepFall.Intensity = myModel.Intensity3;
                        myModel.MyBL.AddReportFall(myModel.CurRepFall);
                    }
                }

                ViewService.AddRepMessage();



                // CurrentModel.Bl.AddReportFall(CurrentModel.CurRepFall);
                myModel = new ReportFallModel();
                OnPropertyChanged("CurRep");
                OnPropertyChanged("IntensityRepFall");
                OnPropertyChanged("Intensity2RepFall");
                OnPropertyChanged("Intensity3RepFall");
                OnPropertyChanged("boomsRepFall");
                //  ViewService.CleanFieldes();
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
    }
}