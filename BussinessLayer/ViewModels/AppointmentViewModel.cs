using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

       
        public string Patient { get; set; }

         public string Pysician { get; set; }

         public DateTime DateOfVisit { get; set; }

         public int Payment { get; set; }

        
    }
}
