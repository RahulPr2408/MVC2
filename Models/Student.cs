using System.ComponentModel.DataAnnotations;

namespace MVC_2.Models {

    public class Student {
        [Key]
        public int student_ID {get; set;}

        [Required]
        public string? student_Name {get; set;}

        [Required]
        public int student_age {get; set;}

        [Required(ErrorMessage = "Mobile number is required!!!")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long student_Contact {get; set; }
    }
}

