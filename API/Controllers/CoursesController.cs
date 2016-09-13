using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursesAPI.Models;
using CoursesAPI.Services;

namespace CoursesAPI.API.Controllers
{
    // Gögn sem API skilar -> DTO
    // Gögn sem API tekur inn -> ViewModel
    // klasar sem mappast töflur -> Entity


	/// <summary>
    /// API that can be used to get, update and delete information about courses.
	/// The API can get students in a ceratin course and also add student in a course.
    /// </summary>
    [Route("api/courses")]
    public class CoursesController : Controller
    {
		/// <summary>
        /// Instance varible of the ICoursesService class.
        /// </summary>
        private readonly ICoursesService _service;

		/// <summary>
        /// Constructer
        /// </summary>
        /// <param name="service"></param>
        public CoursesController(ICoursesService service)
        {
            _service = service;
        }

		/// <summary>
        /// Returns minimal information about the courses in the given semester.
		/// If the semester is null than it returns all the classes in current semester.
		///
		/// Every year is split into three semesters, example: 20151, 20152 and 20153
        /// </summary>
        /// <param name="semester"> Example: 20163 </param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCoursesOnSemester(string semester = null)
        {
			var result = _service.GetCoursesBySemester(semester);

			if(result == null)
			{
				return StatusCode(404); 
			}

            return new ObjectResult(result);
        }

		/// <summary>
        /// Gets detail information about the course given by the id.
		///
        /// returns 404 error code if the course is not in the database.
		/// </summary>
        /// <param name=""{id:int}""></param>
        /// <param name="id"> the id of the course </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name="GetCourseById")]
        public IActionResult GetCourseDetails(int id)
        {
            var result = _service.GetByID(id);

			if(result == null)
			{
				return StatusCode(404); 
			}
			
			return new ObjectResult(result);
        }

		/// <summary>
        /// Updates the course that is given by the id.
		/// The properties which are be mutable are StartDate and EndDate.
		///
        /// returns 404 error code if the course is not in the database. 
		/// </summary>
        /// <param name=""{id:int}""></param>
        /// <param name="id"></param>
        /// <param name="course"></param>
        /// <returns> returns 202 status code if everthing was ok. </returns>
		[HttpPut]
        [Route("{id:int}", Name = "UpdateCourse")]
        public IActionResult UpdateCourse(int id, CourseViewModel course)
        {

			CourseDetailDTO c = new CourseDetailDTO {
				ID = id,
				StartDate = course.StartDate,
				EndDate = course.EndDate
			};

			try
			{
				_service.UpdateCourse(c);
			}
			catch(CourseDoesNotExistException)
			{
				return StatusCode(404);
			}
		
			return StatusCode(202);
        }

		/// <summary>
        /// Deletes the course given by the id.
		///
        /// returns 404 error code if the course is not in the database. 
		/// </summary>
        /// <param name=""{id:int}""></param>
        /// <param name="id"></param>
        /// <returns> returns 202 status code if everthing was ok. </returns>
		[HttpDelete]
        [Route("{id:int}", Name="DeleteCourseById")]
        public IActionResult DeleteCourse(int id)
        {
			try
			{
				_service.DeleteCourse(id);
			}
			catch(CourseDoesNotExistException )
			{
				return StatusCode(404); 
			}

			return StatusCode(202);
        }
        	
		/// <summary>
        /// Return all the students that are registered in the course given by the id.
		///
        /// returns 404 error code if the course is not in the database.  
		/// </summary>
        /// <param name=""{id:int}/students""></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/students", Name = "GetStudentsByCourseId")]
        public IActionResult GetStudentsByCourseId(int id)
        {	
			List<StudentDTO> result = null;

			try
			{
				result = _service.GetStudentsByCourseId(id);
			}
			catch(CourseDoesNotExistException )
			{
				return StatusCode(404);
			}

			return new ObjectResult(result);
        }
	
		/// <summary>
        /// Adds a student in the course given by the id.
		///
        /// returns 404 error code if the course is not in the database.  
		/// </summary>
        /// <param name=""{id:int}/students""></param>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns> returns 202 status code if everthing was ok. </returns>
        [HttpPost]
        [Route("{id:int}/students", Name = "AddStudentInCourse")]
        public IActionResult AddStudentInCourse(int id, StudentViewModel value)
        {
			if(value.SSN == null || value.Name == null)
			{
				return BadRequest();
			}

			StudentDTO s = new StudentDTO{
				SSN = value.SSN,
				Name = value.Name
			};
		
			try
			{
				_service.AddStudentInCourse(id, s);
			}
			catch(CourseDoesNotExistException )
			{
				return StatusCode(404);
			}

			return StatusCode(202);
		}
    }


}