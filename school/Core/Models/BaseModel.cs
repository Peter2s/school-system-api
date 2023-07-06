using System.ComponentModel.DataAnnotations;

namespace school.Core.Models
{
    public class BaseModel
    {
        [Required]
        public long Id { get; set; }
    }
}
