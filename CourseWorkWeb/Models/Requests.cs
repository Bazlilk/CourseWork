using System.ComponentModel.DataAnnotations;

namespace CourseWorkWeb.Models
{
    public class Requests
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Range(1,12,ErrorMessage = "Значение должно быть от 1го до 12ти")]
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public DateTime RequestCreateDateTime { get; set; } = DateTime.Now;
    }
}
