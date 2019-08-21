using AutoMapper;
using OutXApp.Core;
using OutXApp.Core.Dto;
using OutXApp.Core.Models;
using System.Linq;
using System.Web.Http;

namespace OutXApp.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IHttpActionResult GetCourses()
        {
            var CoursesQuery = _unitOfWork.Courses.GetCourses();


            var CourseDto = CoursesQuery.ToList()
                                          .Select(Mapper.Map<Course, CourseDto>);

            return Ok(CourseDto);

        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var Course = _unitOfWork.Courses.GetCourse(id);
            _unitOfWork.Courses.Remove(Course);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
