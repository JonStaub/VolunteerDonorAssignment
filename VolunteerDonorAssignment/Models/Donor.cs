using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerDonorAssignment.Models
{
    public class Donor
    {
        [Key]
        public int DonorId { get; set; } 
        [DisplayName("First Name")] [Required(ErrorMessage ="Please enter a Name")]
        
        public string FirstName { get; set; } 
        [DisplayName("Last Name")] [Required(ErrorMessage ="Please enter a Name")]
        public string LastName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } //Only want to store the most recent phone number, delete old phone numbers on update
        
        public virtual ICollection<Donation> Donations { get; set; }
        [DisplayName("Note")]
        public virtual ICollection<DonorNote> DonorNotes { get; set; }
        [DisplayName("Email")] [EmailAddress]
        public virtual ICollection<Email> Emails { get; set; }

    }
}
