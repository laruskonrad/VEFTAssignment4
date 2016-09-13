namespace CoursesAPI.Services.Entities
{
    /// <summary>
    /// Entity class that maps to a Student table in the database.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Auto incremented primary key. 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The social security number of the student. Example: 1234567890
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// The name of the student.
        /// </summary>
        public string Name { get; set; }
    }
}