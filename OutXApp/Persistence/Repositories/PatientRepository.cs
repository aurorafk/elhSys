using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OutXApp.Core.Models;
using OutXApp.Core.Repositories;

namespace OutXApp.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.Include(c => c.Cities);
        }

        /// <summary>
        /// /Get single Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course GetCourse(int id)
        {
            return _context.Courses
                .Include(c => c.Cities)
                .SingleOrDefault(p => p.Id == id);
            //return _context.Courses.Find(id);
        }
        /// <summary>
        /// Get newly added Courses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Course> GetRecentCourses()
        {
            return _context.Courses
                .Where(a => DbFunctions.DiffDays(a.DateTime, DateTime.Now) == 0)
                .Include(c => c.Cities);
        }



        /// <summary>
        /// Add new Course
        /// </summary>
        /// <param name="Course"></param>
        public void Add(Course Course)
        {
            _context.Courses.Add(Course);
        }
        /// <summary>
        /// Delete existing Course
        /// </summary>
        /// <param name="Course"></param>
        public void Remove(Course Course)
        {
            _context.Courses.Remove(Course);
        }
    }
}