using System.ComponentModel.DataAnnotations.Schema;

namespace Advanced_Csharp_Lab2_Blazor.Models.sqlite
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Teachers")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
