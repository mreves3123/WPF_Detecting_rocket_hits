using PL.Commands;
using PL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace PL.ViewModel
{
    class ReportViewModel : INotifyPropertyChanged, IReportViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ReportModel CurrentModel { get; set; }

        public AddReportCommand addRepCom { get; set; }

        public BE.ReportFall TheReportFall
        {
            get { return CurrentModel.CurRepFall; }
            set { CurrentModel.CurRepFall = value; }
        }

        public ReportViewModel()
        {
            CurrentModel = new ReportModel();
            addRepCom = new AddReportCommand(this);
        }

        public void AddNewReport()
        {
            //CurrentModel.CurRepFall.CoordinateR = CurrentModel.Bl.GetCoordinate(CurrentModel.CurRepFall.City, CurrentModel.CurRepFall.Address);
            CurrentModel.CurRepFall.CoordinateR = new Coordinate(1, 1);
            CurrentModel.Bl.AddReportFall(CurrentModel.CurRepFall);
        }
    }
}
