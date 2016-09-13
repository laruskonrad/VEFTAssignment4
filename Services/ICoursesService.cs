using System.Collections.Generic;
using CoursesAPI.Models;

namespace CoursesAPI.Services
{
    /// <summary>
    /// Interface for CourseService.
    /// </summary>
    public interface ICoursesService
    {
        List<CourseLiteDTO> GetCoursesBySemester(string semester);

        CourseDetailDTO GetByID(int id);

        void UpdateCourse(CourseDetailDTO course);

        void DeleteCourse(int id);

        List<StudentDTO> GetStudentsByCourseId(int id);

        void AddStudentInCourse(int id, StudentDTO newStudent);
    }
}