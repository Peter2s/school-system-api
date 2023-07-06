using System.ComponentModel.DataAnnotations;

namespace school.Dtos.StudentDtos
{
    public class AddStudentDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        [Required]
        public string Note { get; set; }
    }
}
