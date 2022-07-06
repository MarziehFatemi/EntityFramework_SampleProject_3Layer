using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Customer
    {
        [Key,MaxLength(30)]
        public string  UserName{ get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }


        [MaxLength(30)]
        public string Email { get; set; }

        [Column(TypeName = "Int")]
        public int TotalPayment { get; set; }
    }
}
