using System;
using System.Web.Mvc;
using OutXApp.Core;
using OutXApp.Core.ViewModel;

namespace OutXApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //======================Attandance ========================//
        public ActionResult Attandences()
        {
            var attandences = _unitOfWork.Attandences.GetAttandences();
            return View(attandences);
        }
        public ActionResult CourseAttandence(string token = null)
        {
            var CourseAttandences = _unitOfWork.Attandences.GetCourseAttandences(token);
            return View("_AttandencePartial", CourseAttandences);
        }

        // ===============Appointment ========================//
        public ActionResult Appointments()
        {
            var appointments = _unitOfWork.Appointments.GetAppointments();
            return View(appointments);
        }

        [HttpPost]
        public ActionResult Appointments(AppointmentSearchVM viewModel)
        {
            var filter = _unitOfWork.Appointments.FilterAppointments(viewModel);
            return View(filter);
        }
        public ActionResult TestAppointment(AppointmentSearchVM viewModel)
        {
            var filter = _unitOfWork.Appointments.FilterAppointments(viewModel);
            return PartialView("_Appointments", filter);
        }
        //===============End Appointment===================//

        //====================Daily appointment==============//

        public ActionResult DaillyAppointments()
        {
            var daily = _unitOfWork.Appointments.GetAppointments();
            return View(daily);
        }

        public ActionResult Dailly(DateTime getDate)
        {
            var dailyAppointments = _unitOfWork.Appointments.GetDaillyAppointments(getDate);
            return View("_DailyAppointments", dailyAppointments);
        }
    }
}