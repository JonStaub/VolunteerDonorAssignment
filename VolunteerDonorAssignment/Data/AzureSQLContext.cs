using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerDonorAssignment.Models;

namespace VolunteerDonorAssignment.Data
{
    public class AzureSQLContext : DbContext
    {
        public AzureSQLContext(DbContextOptions<AzureSQLContext> options) : base(options) //This database represents the data on Bloomerang
        {

        }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<DonorNote> DonorNotes { get; set; }
    }
}