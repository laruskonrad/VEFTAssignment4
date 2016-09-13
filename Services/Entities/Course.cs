namespace CoursesAPI.Services.Entities
{
    /// <summary>
    /// Entity class that maps to a Course table in the database
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Auto incremented primary key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Semester of the course. Example: 20161
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// Foreign key to the CourseTemplates table
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// The day that the course starts in a string format. Example: 20/06/2015 
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// The day that the course ends in a string format. Example: 19/12/2015 
        /// </summary>
        public string EndDate { get; set; }
    }
}