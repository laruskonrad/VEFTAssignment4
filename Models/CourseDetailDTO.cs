using System;

namespace CoursesAPI.Models
{
    /// <summary>
    /// Model class that descripes the details of the course. 
    /// </summary>
    public class CourseDetailDTO
    {
        /// <summary>
        /// Database-generated ID of course
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the course.
        /// Example: "Web Services"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Example: 20163 -> fall 2016
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// The amount of credits the course gives
        /// Example: 6
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// The day that the course starts in a string format.
        /// Example: 21/06/2015
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// The day that the course ends in a string format.
        /// Example: 15/12/2015
        /// </summary>
        public string EndDate { get; set; }
    }
}