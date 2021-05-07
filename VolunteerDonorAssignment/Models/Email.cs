using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerDonorAssignment.Models
{
    public class Email
    {
        [Key]
        public int EmailId { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }        
        
        [ForeignKey("DonorId")]
        public int DonorId {get; set;}
        public Donor Donor { get; set; }


        [ForeignKey("VolunteerId")]
        public int VolunteerId { get; set; }        
        public Volunteer Volunteer { get; set; }
    }
}
