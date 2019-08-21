using System;
using System.Linq;
using System.Web.Mvc;
using OutXApp.Core;
using OutXApp.Core.Models;
using OutXApp.Core.ViewModel;

namespace OutXApp.Controllers
{
    [Authorize(Roles = RoleName.DoctorRoleName + "," + RoleName.AdministratorRoleName)]
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var viewModel = new CourseDetailViewModel()
            {
                Course = _unitOfWork.Courses.GetCourse(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentWithCourse(id),
                Attendances = _unitOfWork.Attandences.GetAttendance(id),
                CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
                CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
            };
            return View("Details", viewModel);
        }




        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseFormViewModel
            {
                Cities = _unitOfWork.Cities.GetCities(),
                Heading = "New Course"
            };
            return View("CourseForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                return View("CourseForm", viewModel);

            }

            var Course = new Course
            {
                Name = viewModel.Name,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                DateTime = DateTime.Now,
                BirthDate = viewModel.GetBirthDate(),
                Height = viewModel.Height,
                Weight = viewModel.Weight,
                CityId = viewModel.City,
                Sex = viewModel.Sex,
                Token = (2018 + _unitOfWork.Courses.GetCourses().Count()).ToString().PadLeft(7, '0')
            };

            _unitOfWork.Courses.Add(Course);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Courses");

            // TODO: BUG redirect to detail 
            //return RedirectToAction("Details", new { id = viewModel.Id });
        }


        public ActionResult Edit(int id)
        {
            var Course = _unitOfWork.Courses.GetCourse(id);

            var viewModel = new CourseFormViewModel
            {
                Heading = "Edit Course",
                Id = Course.Id,
                Name = Course.Name,
                Phone = Course.Phone,
                Date = Course.DateTime,
                //Date = Course.DateTime.ToString("d MMM yyyy"),
                BirthDate = Course.BirthDate.ToString("dd/MM/yyyy"),
                Address = Course.Address,
                Height = Course.Height,
                Weight = Course.Weight,
                Sex = Course.Sex,
                City = Course.CityId,
                Cities = _unitOfWork.Cities.GetCities()
            };
            return View("CourseForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CourseFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                return View("CourseForm", viewModel);
            }


            var CourseInDb = _unitOfWork.Courses.GetCourse(viewModel.Id);
            CourseInDb.Id = viewModel.Id;
            CourseInDb.Name = viewModel.Name;
            CourseInDb.Phone = viewModel.Phone;
            CourseInDb.BirthDate = viewModel.GetBirthDate();
            CourseInDb.Address = viewModel.Address;
            CourseInDb.Height = viewModel.Height;
            CourseInDb.Weight = viewModel.Weight;
            CourseInDb.Sex = viewModel.Sex;
            CourseInDb.CityId = viewModel.City;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Courses")
;
        }



    }
}