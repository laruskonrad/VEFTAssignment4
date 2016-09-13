using System;

namespace CoursesAPI.Models
{
    /// <summary>
    /// Model class that descripes the student.
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// The social security of the student.
        /// Example: 0706943609
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// The name of the student.
        /// Example: Jón Sigurðsson
        /// </summary>
        public string Name { get; set; }
    }
}