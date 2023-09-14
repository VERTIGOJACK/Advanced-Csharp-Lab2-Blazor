using Advanced_Csharp_Lab2_Blazor.Models.sqlite;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Csharp_Lab2_Blazor.Data
{
    public class SQLiteService
    {
        private readonly SchoolContext context;

        public SQLiteService(SchoolContext context)
        {
            this.context = context;
        }

        public async Task<List<Teacher>> ReadTeachersAsync()
        {
            return await context.Teachers.ToListAsync();
        }
        public async Task<Teacher> ReadTeacherAsync(int id)
        {
            //tries to fetch teacher using id. if none is found, return new empty teacher object
            //null coalescing operator provides a fallback value if value is null
            return await context.Teachers.Where(teacher => teacher.Id == id).FirstOrDefaultAsync<Teacher>() ?? new Teacher();
        }
        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await context.Teachers.AddAsync(teacher);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            //no updateasync, reevalute if not workin
            context.Teachers.Update(teacher);
            await context.SaveChangesAsync();
        }
        public async Task DeleteTeacherAsync(Teacher teacher)
        {
            //same here
            context.Teachers.Remove(teacher);
            await context.SaveChangesAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<Course>> ReadCoursesAsync()
        {
            return await context.Courses.ToListAsync();
        }
        public async Task<Course> ReadCourseAsync(int id)
        {
            //tries to fetch course using id. if none is found, return new empty Course object
            //null coalescing operator provides a fallback value if value is null
            return await context.Courses.Where(course => course.Id == id).FirstOrDefaultAsync<Course>() ?? new Course();
        }
        public async Task CreateCourseAsync(Course course)
        {
            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            //no updateasync, reevalute if not workin
            context.Courses.Update(course);
            await context.SaveChangesAsync();
        }
        public async Task DeleteCourseAsync(Course course)
        {
            //same here
            context.Courses.Remove(course);
            await context.SaveChangesAsync();
        }

        // unsure if this should be part of the service, or if its bloating
        public async Task AddTeacherToCourseAsync(Teacher teacher, Course course)
        {
            //if teacher not in course, add teacher
            if (!course.Teachers.Contains(teacher))
            {
                course.Teachers.Add(teacher);
                //update course record in db
                context.Courses.Update(course);
                //save changes
                await context.SaveChangesAsync();
            }

        }
        public async Task RemoveTeacherFromCourseAsync(Teacher teacher, Course course)
        {
            //if teacher not in course, remove teacher
            if (course.Teachers.Contains(teacher))
            {
                course.Teachers.Remove(teacher);
                //update course record in db
                context.Courses.Update(course);
                //save changes
                await context.SaveChangesAsync();
            }
        }

    }
}
