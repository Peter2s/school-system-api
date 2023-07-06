using school.Core.Models;

namespace school.Services
{
    public class StudentService
    {
        private static List<Student> studentsList { get; }
        static StudentService()
        {
            studentsList = new List<Student>();
        }


        public static List<Student> getAll() => studentsList;
        public static void add(List<Student> students)
        {
            studentsList.Concat(students).ToList();
        }
    }
}
