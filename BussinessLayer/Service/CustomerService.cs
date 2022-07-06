using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using BussinessLayer.ViewModels;

namespace BussinessLayer.Service
{
    public class CustomerService
    {
        public List <CustomerViewModel> GetAllCustomers()
        {
           
                using (var db = new HiExpertDataBaseContext())
            {

                return db.Customers.Select(v => new CustomerViewModel
                {
                    Name = v.Name,
                    UserName = v.UserName,
                    Phone = v.Phone,
                    Email = v.Email,
                    TotalPayment = v.TotalPayment,
                }).ToList();  
            }
               
        }

        public CustomerViewModel GetACustomer(string UserName)
        {
            var User = new CustomerViewModel();

            using (var db = new HiExpertDataBaseContext())
            {
                

                User = db.Customers.Where(v => v.UserName == UserName).Select(v => new CustomerViewModel
                {
                    Name = v.Name,
                    UserName = v.UserName,
                    Phone = v.Phone,
                    Email = v.Email,
                    TotalPayment = v.TotalPayment
                }).FirstOrDefault(); 
            }
            return User; 

        }


        public int AddCustomer(string UserName, string Name, string Phone, string Email,  out string Error)
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
                    List<CustomerViewModel> AllCs = GetAllCustomers(); 
                    foreach (var c in AllCs)
                    {
                        if (c.UserName == UserName)
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
                            var NewCustomer = new Customer();

                            NewCustomer.UserName = UserName;
                            NewCustomer.Name = Name;
                            NewCustomer.Phone = Phone;
                            NewCustomer.Email = Email;

                            db.Customers.Add(NewCustomer);
                            db.SaveChanges();
                            Error = "The User is Added Succussfully";
                            return 1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch  (Exception e)
                {
                    Error = e.ToString();
                    return -2; 
                }

            }

        }


        public bool RemoveCustomer(string UserName, string Error)
        {
            Error = string.Empty;

            if (UserName == "")
            {
                return false;
                Error = "Please fill The UserName";
            }
            else
            {
                using (var db = new HiExpertDataBaseContext())
                {
                    var DeletedCustomer = db.Customers.Where(e => e.UserName == UserName).FirstOrDefault();
                    if (DeletedCustomer != null)
                    {
                        try
                        {
                            db.Customers.Remove(DeletedCustomer);
                            db.SaveChanges();

                            Error = "The User is removed Succussfully";
                            return true;
                        }
                        catch (Exception e )
                        {
                            Error = e.ToString();
                            return false;
                        }
                    }
                    else
                    {
                        Error = "The User deos not exist";
                        return false;
                    }
                }

                }

        }

        public bool UpdateCustomer(string UserName, string Name, string Phone, string Email, out string Error, params object [] List)
        {
            Error = string.Empty;

            if (UserName == "" || Name == "" )
            {
                
                Error = "Please fill all the texts";
                return false;
            }
            else
            {
                using (var db = new HiExpertDataBaseContext())
                {
                    var UpdatingCustomer = db.Customers.Where(e => e.UserName == UserName).FirstOrDefault();

                    if (UpdatingCustomer != null)
                    {
                        UpdatingCustomer.Name = Name;
                        UpdatingCustomer.Phone = Phone;
                        UpdatingCustomer.Email = Email;
                        

                        if (List != null && List.Length >=1)
                        {
                            UpdatingCustomer.TotalPayment = (int)List[0];
                        }


                        db.SaveChanges();
                        Error = "The User is Edited Succussfully";
                        return true;
                    }
                    else
                    {
                        Error = "You can not edit the username";
                        return false;

                    }
                }

            }

        }


    }
}
