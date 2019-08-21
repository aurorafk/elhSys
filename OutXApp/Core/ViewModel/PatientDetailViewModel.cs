using System.Collections.Generic;
using OutXApp.Core.Models;

namespace OutXApp.Core.ViewModel
{
    public class CourseDetailViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public int CountAppointments { get; set; }
        public int CountAttendance { get; set; }
    }
}