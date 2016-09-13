namespace CoursesAPI.Services.Entities
{
    /// <summary>
    /// Entity class that maps to a table in the database.
    /// This class joins together Student and Course.
    /// Holds information about what Student are registerd in wich courses.
    /// </summary>
    public class StudentsInCourses
    {
        /// <summary>
        /// Auto incremented primary key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key from the student table.
        /// </summary>
        public string StudentSSN { get; set; }

        /// <summary>
        /// Foreign key from the Course table.
        /// </summary>
        public int CourseID { get; set; }
    }
}