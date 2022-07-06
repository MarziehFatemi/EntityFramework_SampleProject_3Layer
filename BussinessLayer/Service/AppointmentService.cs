using BussinessLayer.ViewModels;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Service
{
    public  class AppointmentService
    {

        public List<AppointmentViewModel> GetAllAppointments()
        {

            using (var db = new HiExpertDataBaseContext())
            {

                return db.Appointments.Select(v => new AppointmentViewModel
                {
                    Patient = v.Patient,
                    Pysician = v.Pysician,
                    DateOfVisit = v.DateOfVisit,
                    Payment = v.Payment,
                    Id = v.Id,
                    
                }).ToList();
            }

        }

        public List<AppointmentViewModel> GetAnAppointment(int Id)
        {

            using (var db = new HiExpertDataBaseContext())
            {

                return db.Appointments.Where(v => v.Id == Id).Select(v => new AppointmentViewModel
                {
                    Patient = v.Patient,
                    Pysician = v.Pysician,
                    DateOfVisit = v.DateOfVisit,
                    Payment = v.Payment,
                    Id = v.Id,
                }).ToList();
            }

        }

        public bool AddAppointment(string Dr, string Patient, DateTime Date, int Payment, out string Error)
        {
            Error = string.Empty;

                
                                    
            if (Patient == "" || Dr == "" || Date.ToString() == ""  ||Payment <=0)
            {         
                
                Error = "Please fill all the texts with valid values";
                return false;
            }
            else
            {
                try
                {
                    using (var db = new HiExpertDataBaseContext())
                    {
                        var NewAppointment = new Appointment();

                       
                        NewAppointment.Patient = Patient;
                        NewAppointment.Pysician = Dr;
                        NewAppointment.Payment = Payment;
                        NewAppointment.DateOfVisit = Date;

                        db.Appointments.Add(NewAppointment);
                        db.SaveChanges();
                        Error = "The Appointment is Added Succussfully";
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Error = e.ToString();
                    return false;
                }

            }

        }


        public bool RemoveAppointment(int Id, string Error)
        {
            Error = string.Empty;

            if (Id <0)
            {
                return false;
                Error = "wrong selection";
            }
            else
            {
                using (var db = new HiExpertDataBaseContext())
                {
                    var DeletedAppointment = db.Appointments.Where(e => e.Id == Id).FirstOrDefault();
                    if (DeletedAppointment != null)
                    {
                        try
                        {
                            db.Appointments.Remove(DeletedAppointment);
                            db.SaveChanges();

                            Error = "The appointment is removed Succussfully";
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
                        Error = "The appointment is null";
                        return false;
                    }
                }

            }

        }

        public bool UpdateAppoitment(int Id, string Patient, string Dr, DateTime DateOfVisit, int Payment, out string Error)
        {
            Error = string.Empty;
            if (Id < 0)
            {
                return false;
                Error = "Invalid Selection";
            }
            else
            {
                if ( Patient == "" || Dr == "" || DateOfVisit.ToString() == "" || Payment <0 )
                {
                    return false;
                    Error = "Please fill all the texts with valid values";
                }
                else
                {
                    using (var db = new HiExpertDataBaseContext())
                    {
                        var UpdaatingAappointment = db.Appointments.Where(e => e.Id == Id).FirstOrDefault();

                        if (UpdaatingAappointment == null)
                        {
                            Error = "The Appointment is null";
                            return false;
                        }
                        else
                        {
                            UpdaatingAappointment.Patient = Patient;
                            UpdaatingAappointment.Pysician = Dr;
                            UpdaatingAappointment.Payment = Payment;
                            UpdaatingAappointment.DateOfVisit = DateOfVisit;


                            db.SaveChanges();
                            Error = "The Appointment is Updated Succussfully";
                            return true;
                        }
                    }

                }
            }

        }


    }
}
