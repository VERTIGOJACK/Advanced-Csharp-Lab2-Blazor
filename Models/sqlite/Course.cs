using System.ComponentModel.DataAnnotations.Schema;

namespace Advanced_Csharp_Lab2_Blazor.Models.sqlite
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //inverse navigation property, Courses refer to the collection of courses in the teacher class, and vice versa.
        [InverseProperty("Courses")]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
