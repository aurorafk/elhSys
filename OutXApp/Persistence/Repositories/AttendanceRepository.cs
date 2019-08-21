using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OutXApp.Core.Models;
using OutXApp.Core.Repositories;

namespace OutXApp.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetAttandences()
        {
            return _context.Attendances.ToList();
        }
        /// <summary>
        /// Get attandences for single Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetAttendance(int id)
        {
            return _context.Attendances.Where(p => p.CourseId == id).ToList();
        }
        /// <summary>
        /// search  attandences for Course by token 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetCourseAttandences(string searchTerm = null)
        {
            var attandences = _context.Attendances.Include(p => p.Course);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                attandences = attandences.Where(p => p.Course.Token.Contains(searchTerm));
            }
            return attandences.ToList();
        }
        /// <summary>
        /// Get number of attendances for defined Course 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountAttendances(int id)
        {
            return _context.Attendances.Count(a => a.CourseId == id);
        }
        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }
    }
}