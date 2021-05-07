using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerDonorAssignment.Models
{
    public class DonorNote
    {
        [Key]
        public int DonorNoteId { get; set; }
        public DateTime EntryDate { get; set; }
        public string Note { get; set; }
        public int DonorId { get; set; }
        [ForeignKey("DonorId")]
        public Donor Donor { get; set; }
        [ForeignKey("VolunteerId")]
        public int VolunteerId { get; set; }
        
    }
}
