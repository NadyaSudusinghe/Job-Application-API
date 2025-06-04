using JobTrackerAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Data
{
    public class JobTrackerDbContext(DbContextOptions<JobTrackerDbContext> options): DbContext(options)
    {
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
        //create db context


    }
}
