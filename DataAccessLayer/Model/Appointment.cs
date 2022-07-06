using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Appointment
    {
        public int Id { get; set; }

        [MaxLength (30)]
        public string Patient { get; set; }

        [MaxLength(30)]
        public string Pysician { get; set; }

        
        public DateTime DateOfVisit { get; set; }

        [Column(TypeName = "Int")]
        public int Payment { get; set; }

        [ForeignKey("Patient")]
        public virtual Customer Customers { get; set; }

        [ForeignKey("Pysician")]
        public virtual Doctor Doctors { get; set; }


    }
}
