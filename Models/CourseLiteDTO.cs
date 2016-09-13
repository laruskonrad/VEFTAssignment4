using System;

namespace CoursesAPI.Models
{
    /// <summary>
    /// Model class that descripes minimun information about the course.
    /// </summary>
    public class CourseLiteDTO
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
    }
}
