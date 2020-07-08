using BE;
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
    public class GraphVM:IGraphFall,INotifyPropertyChanged
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public RefreshGraphCommand MyCom { get; set; }
        public GraphModel myModel { get; set; }
        public GraphVM(View.IRefGraphViesService vs)
        {
            myModel = new GraphModel();
            MyCom = new RefreshGraphCommand(this);
            viewService = vs;
            FromDate = DateTime.Today;

            ToDate = DateTime.Today;
        }
        public View.IRefGraphViesService viewService;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        public void DisFallArg()
        {
            try
            {
                List<Fall> relevantFalls = myModel.MyBL.FallsBetweenDates(FromDate, ToDate);
                string[] dataArrID = new string[relevantFalls.Count];
                double[] dataArrDistance = new double[relevantFalls.Count];
                //           OnPropertyChanged("");
                for (int i = 0; i < relevantFalls.Count; i++)
                {
                    double result = myModel.MyBL.disAcordFall(relevantFalls[i]);
                    if (result != -1)
                    {
                        result = Math.Round(result, 2);
                        dataArrDistance[i] = result;
                        dataArrID[i] = "" + relevantFalls[i].FallId;
                        //dataArrDistance[i] = (i*30 + 10) / 10;
                    }
                    else
                    {

                    }
                }

                viewService.refGraph(dataArrID, dataArrDistance);
            }
            catch (Exception e)
            {
                viewService.ViewErrMsg(e.Message);
            }
        }
    }
}

