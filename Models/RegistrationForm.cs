using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultipleCourses.Models
{
    public class RegistrationForm
    {
        public RegistrationForm()
        {
            qualifications = new List<Qualification>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Age { get; set; }

        [AtLeastOneQualificationRequired(ErrorMessage ="Atleast one qualification is required")]
        public IList<Qualification> qualifications { get; set; }
        
    }
    public class Qualification
    {
        [Key]
        public int QualificationId { get; set; }
        [Required(ErrorMessage ="Course name is required")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Year of pass is required")]
        public string YearofPass { get; set; }
        [Required(ErrorMessage = "University is required")]
        public string University { get; set; }
        public int RegistrationFormId { get; set; }

        public RegistrationForm RegistrationForm { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple =false)]
    public class AtLeastOneQualificationRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ICollection<Qualification> collection)
            {
                return collection.Count > 0;
            }
            return false;
        }
    }
}
