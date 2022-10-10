using Microsoft.EntityFrameworkCore;

namespace Student_Courses.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options):base(options){ }

        public ApplicationDbContext()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Nationality> Nationality { get; set; }


    }
}
