using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.ViewModels; 

namespace BussinessLayer.Service
{
    public class DoctorService
    {

        public List<DoctorViewModel> GetAllDrs()
        {
           
            using (var db = new HiExpertDataBaseContext())
            {

                return db.Doctors.Select(v => new DoctorViewModel
                {
                    Name = v.Name,
                    UserName = v.UserName,
                    Phone = v.Phone,
                    CardNumber= v.CardNumber,
                    AccountNumber = v.AccountNumber,
                    TotalCheckedOut = v.TotalCheckedOut,
                    TotalSale  = v.TotalSale,
                    TotalIncome = v.TotalIncome,
                    CommissionPercent = v.CommissionPercent,
                    Credit= v.Credit
                }).ToList();
            }

        }

        public DoctorViewModel GetADr(string UserName)
        {
            var Dr = new DoctorViewModel(); 

            using (var db = new HiExpertDataBaseContext())
            {

                Dr = db.Doctors.Where(v => v.UserName == UserName).Select(v => new DoctorViewModel
                {
                    Name = v.Name,
                    UserName = v.UserName,
                    Phone = v.Phone,
                    CardNumber = v.CardNumber,
                    AccountNumber = v.AccountNumber,
                    TotalCheckedOut = v.TotalCheckedOut,
                    TotalSale = v.TotalSale,
                    TotalIncome = v.TotalIncome,
                    CommissionPercent = v.CommissionPercent,
                    Credit = v.Credit
                }).FirstOrDefault();
            }

            return Dr;

        }

        public int AddDr(string UserName, string Name, string Phone, string CardNumber, string AccountNumber, int CommissionPercent, out string Error)
        {
            Error = string.Empty;



            if (UserName == "" || Name == "" || Phone == "" )
            {
                
                Error = "Please fill all the texts";
                return -1;
            }
            else
            {
                try
                {
                    bool IsNew = true;
                    List<DoctorViewModel> AllDrs = GetAllDrs();
                    foreach (var D in AllDrs)
                    {
                        if (D.UserName == UserName)
                        {
                            Error = "The UserName is aleardy exist";
                            IsNew = false;
                            
                            break;

                        }
                    }

                    if (IsNew)
                    {
                        using (var db = new HiExpertDataBaseContext())
                        {
                            var NewDr = new Doctor();

                            NewDr.UserName = UserName;
                            NewDr.Name = Name;
                            NewDr.Phone = Phone;
                            NewDr.CardNumber = CardNumber;
                            NewDr.AccountNumber = AccountNumber;
                            NewDr.CommissionPercent = CommissionPercent;
                            db.Doctors.Add(NewDr);
                            db.SaveChanges();
                            Error = "The Doctor is Added Succussfully";
                            return 1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception e)
                {
                    Error = e.ToString();
                    return -2;
                }

            }

        }


        public bool RemoveDr(string UserName, string Error)
        {
            Error = string.Empty;

            if (UserName == "")
            {
                
                Error = "Please fill The UserName";
                return false;
            }
            else
            {
                using (var db = new HiExpertDataBaseContext())
                {
                    var DeletedDr = db.Doctors.Where(e => e.UserName == UserName).FirstOrDefault();
                    if (DeletedDr != null)
                    {
                        try
                        {
                            db.Doctors.Remove(DeletedDr);
                            db.SaveChanges();

                            Error = "The Doctor is removed Succussfully";
                            return true;
                        }
                        catch (Exception e)
                        {
                            Error = e.ToString();
                            return false;
                        }
                    }
                    else
                    {
                        Error = "This Doctor is not exist";
                        return false;
                    }
                }

            }

        }

        ////public bool UpdateDr(string UserName, string Name, string Phone, string CardNumber, string AccountNumber,
        ////int CommissionPercent,int TotalSale, int TotalIncome, int TotalCheckedOut, int Credit, out string Error)
        ////{
        public bool UpdateDr (string UserName, string Name, string Phone, string CardNumber, string AccountNumber,
        int CommissionPercent, int TotalCheckedout, out string Error)
        { 
            Error = string.Empty;

            if (UserName == "" || Name == "" || Phone == "")
            {
                
                Error = "Please fill all the texts";
                return false;
            }
            else
            {
                using (var db = new HiExpertDataBaseContext())
                {
                    var UpdatingDr = db.Doctors.Where(e => e.UserName == UserName).FirstOrDefault();

                    if (UpdatingDr != null)
                    {
                        UpdatingDr.Name = Name;
                        UpdatingDr.Phone = Phone;
                        UpdatingDr.CardNumber = CardNumber;
                        UpdatingDr.AccountNumber = AccountNumber;
                        UpdatingDr.CommissionPercent = CommissionPercent;
                        UpdatingDr.TotalCheckedOut = TotalCheckedout;
                        ////if ((List != null) && (List.Length>=4))
                        ////{
                        ////    UpdatingDr.TotalSale = int.Parse( List[0].ToString());
                        ////    UpdatingDr.TotalIncome = int.Parse(List[1].ToString());
                        ////    UpdatingDr.TotalCheckedOut = int.Parse(List[2].ToString());
                        ////    UpdatingDr.Credit = int.Parse(List[3].ToString());
                        ////}


                        db.SaveChanges();
                        Error = "The Doctor is Edited Succussfully";
                        return true;
                    }
                    else
                    {
                        Error = "You can not change the username";
                        return false;
                    }
                }

            }

        }

        public bool UpdateDr(string UserName, string Name, string Phone, string CardNumber, string AccountNumber,
        int CommissionPercent, out string Error)
        {
            Error = string.Empty;

            if (UserName == "" || Name == "" || Phone == "")
            {

                Error = "Please fill all the texts";
                return false;
            }
            else
            {
                using (var db = new HiExpertDataBaseContext())
                {
                    var UpdatingDr = db.Doctors.Where(e => e.UserName == UserName).FirstOrDefault();

                    if (UpdatingDr != null)
                    {
                        UpdatingDr.Name = Name;
                        UpdatingDr.Phone = Phone;
                        UpdatingDr.CardNumber = CardNumber;
                        UpdatingDr.AccountNumber = AccountNumber;
                        UpdatingDr.CommissionPercent = CommissionPercent;
                        ///UpdatingDr.TotalCheckedOut = TotalCheckedout;
                        ////if ((List != null) && (List.Length>=4))
                        ////{
                        ////    UpdatingDr.TotalSale = int.Parse( List[0].ToString());
                        ////    UpdatingDr.TotalIncome = int.Parse(List[1].ToString());
                        ////    UpdatingDr.TotalCheckedOut = int.Parse(List[2].ToString());
                        ////    UpdatingDr.Credit = int.Parse(List[3].ToString());
                        ////}


                        db.SaveChanges();
                        Error = "The Doctor is Edited Succussfully";
                        return true;
                    }
                    else
                    {
                        Error = "You can not change the username";
                        return false;
                    }
                }

            }

        }

        public bool UpdateDr(string UserName, string Name, string Phone, string CardNumber, string AccountNumber,
        int CommissionPercent,int TotalCheckedout,  int TotalSale, int TotalIncome, int Credit, out string Error)
        {
            Error = string.Empty;

            if (UserName == "" || Name == "" || Phone == "")
            {

                Error = "Please fill all the texts";
                return false;
            }
            else
            {
                using (var db = new HiExpertDataBaseContext())
                {
                    var UpdatingDr = db.Doctors.Where(e => e.UserName == UserName).FirstOrDefault();

                    if (UpdatingDr != null)
                    {
                        UpdatingDr.Name = Name;
                        UpdatingDr.Phone = Phone;
                        UpdatingDr.CardNumber = CardNumber;
                        UpdatingDr.AccountNumber = AccountNumber;
                        UpdatingDr.CommissionPercent = CommissionPercent;

                        UpdatingDr.TotalSale = TotalSale;
                        UpdatingDr.TotalIncome = TotalIncome;
                        UpdatingDr.TotalCheckedOut = TotalCheckedout;
                        UpdatingDr.Credit = Credit; 




                        db.SaveChanges();
                        Error = "The Doctor is Edited Succussfully";
                        return true;
                    }
                    else
                    {
                        Error = "You can not change the username";
                        return false;
                    }
                }

            }

        }

    }
}
