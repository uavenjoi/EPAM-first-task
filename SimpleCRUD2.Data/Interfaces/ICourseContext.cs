using System.Data.Entity;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Data.Interfaces
{
    public interface ICourseContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Lesson> Lessons { get; set; }

        int SaveChanges();
    }
}
