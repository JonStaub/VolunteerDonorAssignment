using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerDonorAssignment.Models
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }
        [Range(0,double.MaxValue, ErrorMessage ="Please use a positive amount")]
        public double Amount { get; set; }

        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        [ForeignKey("DonorId")]
        public Donor Donor { get; set; }
    }
}
