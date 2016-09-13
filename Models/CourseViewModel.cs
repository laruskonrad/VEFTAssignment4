using System;

namespace CoursesAPI.Models
{
    /// <summary>
    /// View Model class wich is used to update information about the course.
    /// </summary>
    public class CourseViewModel
    {
        /// <summary>
        /// The day that the course starts.
        /// Exmaple: 4/01/2015
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// The day that the course ends.
        /// Example: 13/05/2015
        /// </summary>
        public string EndDate { get; set; }
    }
}