using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class DoctorViewModel
    {

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }


        public string CardNumber { get; set; }

        public string AccountNumber { get; set; }

         public int TotalSale { get; set; }


        public int TotalIncome { get; set; }


         public int CommissionPercent { get; set; }



        public int TotalCheckedOut { get; set; }

         public int Credit { get; set; }

    }
}
