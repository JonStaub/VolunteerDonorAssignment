using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerDonorAssignment.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string PhoneNumber { get; set; } 
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<DonorNote> DonorNotes { get; set; }
       
    }
}
