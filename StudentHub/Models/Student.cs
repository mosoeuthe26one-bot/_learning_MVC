using System.ComponentModel.DataAnnotations;

namespace StudentHub.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Range(typeof(bool), "true", "true",
            ErrorMessage = "You must accept the code of conduct")]
        public bool AcceptedCodeOfConduct { get; set; }
    }
}