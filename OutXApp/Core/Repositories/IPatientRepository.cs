using System.Collections.Generic;
using System.Linq;
using OutXApp.Core.Models;

namespace OutXApp.Core.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetRecentCourses();
        //IEnumerable<Course> GetCourseByToken(string searchTerm = null);
        Course GetCourse(int id);
        //IQueryable<Course> GetCourseQuery(string query);
        void Add(Course Course);
        void Remove(Course Course);
    }
}
