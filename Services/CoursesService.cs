using System;
using System.Linq;
using System.Collections.Generic;
using CoursesAPI.Models;
using CoursesAPI.Services.Entities;

namespace CoursesAPI.Services
{
    public class CourseDoesNotExistException : Exception {}

    /// <summary>
    /// Service class that talks to the database to get, update and delete data from it.
    /// </summary>
    public class CoursesService : ICoursesService
    {
        private readonly AppDataContext _db;
        public CoursesService(AppDataContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets the courses that are tought on the given semster.
        /// If the semester parameter is null then it returns the courses on current semester.
        /// </summary>
        /// <param name="semester"> Example: 20153 </param>
        /// <returns></returns>
        public List<CourseLiteDTO> GetCoursesBySemester(string semester)
        {
            if (semester == null)
            {
                semester = currentSemester();
            }

            var result = (from c in _db.Course
                where c.Semester == semester
                join ct in _db.CourseTemplate on c.CourseID equals ct.ID
                select new CourseLiteDTO
                {
                    ID = c.ID,
                    Name = ct.Name,
                    Semester = c.Semester 
                }).ToList();

            return result;
        }

        /// <summary>
        /// Private function that returns current semester.
        /// </summary>
        /// <returns></returns>
        private string currentSemester()
        {
            DateTime date = DateTime.Now;
            string year = date.Year.ToString();

            if (1 <= date.Month && date.Month <= 5 )
            {
                year += "1";
            }
            else if ( 6 <= date.Month && date.Month <= 7 )
            {
                year += "2";
            }
            else
            {
                year += "3";
            }

            return year;
        }

        /// <summary>
        /// Gets detailed information about the course given by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourseDetailDTO GetByID(int id)
        {
            var result = (from c in _db.Course
                    where c.ID == id
                    join ct in _db.CourseTemplate on c.CourseID equals ct.ID
                    select new CourseDetailDTO
                    {
                        ID = c.ID,
                        Name = ct.Name,
                        Semester = c.Semester, 
                        Credits = ct.Credits,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate
                    }).SingleOrDefault();

                return result;
        }

        /// <summary>
        /// Private function that checks if the course exsist in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Boolean DoesCourseExsist(int id)
        {
            var result = (from c in _db.Course
                    where c.ID == id
                    select c).SingleOrDefault();

            if(result != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the instance of the course.
        /// The properties which are be mutable are StartDate and EndDate.
        /// </summary>
        /// <param name="course"></param>
        public void UpdateCourse(CourseDetailDTO course)
        {
            if(!DoesCourseExsist(course.ID))
            {
                throw new CourseDoesNotExistException();
            }

            var result = (from c in _db.Course
                    where c.ID == course.ID
                    select c).SingleOrDefault();

            result.StartDate = course.StartDate;
            result.EndDate = course.EndDate;

            try
            {
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
                
            }
        }

        /// <summary>
        /// Deletes the course given by the id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCourse(int id)
        {
            if(!DoesCourseExsist(id))
            {
                throw new CourseDoesNotExistException();
            }

            var result = (from c in _db.Course
                    where c.ID == id
                    select c).SingleOrDefault();

            _db.Course.Remove(result);

            try
            {
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
                
            }
        }

        /// <summary>
        /// Returns a list of all the students that are registerd in the course given by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<StudentDTO> GetStudentsByCourseId(int id)
        {
            if(!DoesCourseExsist(id))
            {
                throw new CourseDoesNotExistException();
            }

            var result = (from c in _db.StudentsInCourses
                    where c.CourseID == id
                    join s in _db.Student on c.StudentSSN equals s.SSN
                        select new StudentDTO
                        {
                            SSN = s.SSN,
                            Name = s.Name
                        }).ToList();

            return result;
        }

        /// <summary>
        /// Adds the the instance of the student in the course given by the id.
        /// The student has to registered in the database to be able to be added in the course. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStudent"></param>
        public void AddStudentInCourse(int id, StudentDTO newStudent)
        {
            if(!DoesCourseExsist(id))
            {
                throw new CourseDoesNotExistException();
            }

            StudentsInCourses s = new StudentsInCourses{
                StudentSSN = newStudent.SSN,
                CourseID = id
            };

            _db.StudentsInCourses.Add(s);

            try
            {
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
                
            }
        }

	
    }
}