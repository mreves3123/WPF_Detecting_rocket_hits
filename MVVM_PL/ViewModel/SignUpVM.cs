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
    public class SignUpVM : ISignUp, INotifyPropertyChanged
    {

        public View.IHavaPssdService PsdViewService { get; set; }
        public View.IAddUserService AddUserViewService { get; set; }
        public SignUpModel myModel { get; set; }
        public SignUpCommand MyCom { get; set; }
        //public SignVM(View.ISignService vs)
        //{
        //    myModel = new SignModel();
        //     MyCom = new LogInCommand(this);
        //    PsdViewService = vs;

        //}
        public SignUpVM()
        {
            myModel = new SignUpModel();
            MyCom = new SignUpCommand(this);
        }
        public SignUpVM(View.IHavaPssdService vs)
        {
            myModel = new SignUpModel();
            MyCom = new SignUpCommand(this);
            PsdViewService = vs;
        }
        public SignUpVM(View.IHavaPssdService vs1, View.IAddUserService vs2)
        {
            myModel = new SignUpModel();
            MyCom = new SignUpCommand(this);
            PsdViewService = vs1;
            AddUserViewService = vs2;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPsd { get; set; }

        public bool Analystic { get; set; }
        public bool Reporter { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void addUser()
        {
            if (UserName == "" || PsdViewService.getPsd1() == "" || PsdViewService.getPsd2() == "" || (!Analystic && !Reporter))
            {
                //לא הכניסו את אחד הפרטים
                AddUserViewService.FieldIsMissing();
            }
            else
            {
                bool result = myModel.MyBL.ThereIsUserName(UserName);
                if (result)
                {
                    //   יש כבר שם משתמש כזה
                    AddUserViewService.NameExist();
                }
                else
                {

                    if (PsdViewService.getPsd1().Equals(PsdViewService.getPsd2()))
                    {
                        if (Reporter && Analystic)
                        {
                            Reporter reporter = new Reporter(UserName, PsdViewService.getPsd1());
                            Analystic analystic1 = new BE.Analystic(UserName, PsdViewService.getPsd1());
                            myModel.MyBL.AddReporter(reporter);
                            myModel.MyBL.AddAnalystic(analystic1);
                        }
                        else
                        {
                            if (Reporter)
                            {
                                Reporter reporter = new Reporter(UserName, PsdViewService.getPsd1());
                                myModel.MyBL.AddReporter(reporter);
                            }
                            else
                            {
                                if (Analystic)
                                {
                                    Analystic analystic1 = new BE.Analystic(UserName, PsdViewService.getPsd1());
                                    myModel.MyBL.AddAnalystic(analystic1);
                                }
                            }
                        }
                        AddUserViewService.AfterSign(UserName, PsdViewService.getPsd1());
                    }
                    else
                    {
                        ///////the password is different
                        AddUserViewService.WrongPsd();
                    }
                }
            }
        }
            //public void CheckUser(string password)
            //{
            //    if (Role.Equals("Reporter"))
            //    {
            //        Reporter reporter = new Reporter(UserName, password);
            //        bool result = myModel.MyBL.IsReporter(reporter);
            //        if (result)
            //            ViewService.LogInReporter();
            //    }

            //    else
            //    {
            //        Analystic analystic = new Analystic(UserName, password);
            //        bool result = myModel.MyBL.IsAnalystic(analystic);
            //        if (result)
            //            ViewService.LogInAnalystic();
            //    }

            //}
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
