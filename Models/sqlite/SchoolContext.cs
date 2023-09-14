using Microsoft.EntityFrameworkCore;

namespace Advanced_Csharp_Lab2_Blazor.Models.sqlite
{
    //database context class
    public class SchoolContext : DbContext
    {
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        //recieve options obj
        public SchoolContext(DbContextOptions options) : base(options)
        { }


    }
}
