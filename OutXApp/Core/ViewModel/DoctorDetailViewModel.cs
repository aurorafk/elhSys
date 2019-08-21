using System.Collections.Generic;
using OutXApp.Core.Models;

namespace OutXApp.Core.ViewModel
{
    public class DoctorDetailViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Appointment> UpcomingAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}