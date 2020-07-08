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
    public class SignVM:INotifyPropertyChanged,ISign
    {

        public View.ISignService ViewService { get; set; }
        public SignModel myModel { get; set; }
        public LogInCommand MyCom { get; set; }
        public SignVM(View.ISignService vs)
        {
            myModel = new SignModel();
            MyCom = new LogInCommand(this);
            ViewService = vs;

        }
        public SignVM()
        {
            myModel = new SignModel();
            MyCom = new LogInCommand(this);
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CheckUser(string password)
        {
            if (UserName == null || Role == null || password == "" || UserName == "")
                ViewService.FieldIsMissing();
            else
            {
                if (Role.Equals("Reporter"))
                {
                    Reporter reporter = new Reporter(UserName, password);
                    bool result = myModel.MyBL.IsReporter(reporter);
                    if (result)
                        ViewService.LogInReporter();
                    else
                        ViewService.WrongPsdName();
                }

                else
                {
                    Analystic analystic = new Analystic(UserName, password);
                    bool result = myModel.MyBL.IsAnalystic(analystic);
                    if (result)
                        ViewService.LogInAnalystic();
                    else
                        ViewService.WrongPsdName();
                }
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
