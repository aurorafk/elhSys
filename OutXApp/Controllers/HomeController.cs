using System;
using OutXApp.Persistence;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OutXApp.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Dashboard Statistics
        public ActionResult TotalCourses()
        {
            var Courses = _context.Courses.ToList();
            return Json(Courses.Count(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalAppointments()
        {
            var appointments =_context.Appointments.ToList();
            return Json(appointments.Count(), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult TotalDoctors()
        //{
        //    var doctors = _context.Doctors.ToList();
        //    return Json(doctors.Count(), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult TotalUsers()
        {
            var users=_context.Users.ToList();
            return Json(users.Count(), JsonRequestBehavior.AllowGet);
        }

        //Today's Courses
        public ActionResult TodaysCourses()
        {
            DateTime today = DateTime.Now.Date;
            var Courses = _context.Courses.Where(p => p.DateTime >= today).ToList();
            return Json(Courses.Count(), JsonRequestBehavior.AllowGet);
        }
        //Todays appointments
        public ActionResult TodaysAppointments()
        {
            DateTime today = DateTime.Now.Date;
            var appointments =_context.Appointments
                .Where(a => a.StartDateTime >= today)
                .ToList();
            return Json(appointments.Count(), JsonRequestBehavior.AllowGet);
        }
        //Available doctors
        public ActionResult AvailableDoctors()
        {
            var doctors=_context.Doctors
                .Where(d => d.IsAvailable)
                .ToList();
            return Json(doctors.Count(), JsonRequestBehavior.AllowGet);
        }
        //Active Accounts
        public ActionResult ActiveAccounts()
        {
            var users =_context.Users
                .Where(u => u.IsActive == true)
                .ToList();
            return Json(users.Count(), JsonRequestBehavior.AllowGet);
        }
        
        #endregion



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}