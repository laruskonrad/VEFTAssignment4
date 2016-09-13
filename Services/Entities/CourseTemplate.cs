namespace CoursesAPI.Services.Entities
{
    /// <summary>
    /// Entity class that maps to a CourseTemplate table in the database
    /// </summary>
    public class CourseTemplate
    {
        /// <summary>
        /// Auto incremented primary key
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The name of the course. Exmple: Programming
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of credits that the course gives. Exmple: 6
        /// </summary>
        public int Credits { get; set; }
    }
}