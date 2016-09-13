using System;

namespace CoursesAPI.Models
{
    /// <summary>
    /// View Model class wich is used to add a student in a certain course.
    /// </summary>
    public class StudentViewModel
    {
        /// <summary>
        /// The social security of the student.
        /// Example: 0706943654
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// The name of the student.
        /// Example: Jón Magnússon
        /// </summary>
        public string Name { get; set; }
    }
}