using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UniversityApp.Models;

namespace UniversityApp.DAL
{
    public class CollegeDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public CollegeDBContext()
        {
            Database.SetInitializer(new CollegeDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}