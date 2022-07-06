using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public  class Doctor
    {

        [Key, MaxLength(30)]
        public string UserName { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }


        [MaxLength(30)]
        public string CardNumber { get; set; }

        [MaxLength(30)]
        public string AccountNumber { get; set; }

        [Column(TypeName = "Int")]
        public int TotalSale { get; set; }


        [Column(TypeName = "Int")]
        public int TotalIncome { get; set; }


        [Column(TypeName = "Int")]
        public int CommissionPercent { get; set; }



        [Column(TypeName = "Int")]
        public int TotalCheckedOut { get; set; }



        [Column(TypeName = "Int")]
        public int Credit { get; set; }


    }
}
