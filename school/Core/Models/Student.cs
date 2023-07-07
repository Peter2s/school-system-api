using System.ComponentModel.DataAnnotations;

namespace school.Core.Models
{
    public class Student : BaseModel
    {
        [Required, StringLength(maximumLength: 15, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required, StringLength(maximumLength: 15, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        public string StudentPhoto { get; set; }
        [Required]
        public string Note { get; set; }


    }
}
