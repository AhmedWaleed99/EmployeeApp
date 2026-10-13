using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModel
{
    public class PenaltyTypeViewModel
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Penalty Name")]
        [MaxLength(70)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Default Amount")]
        [Range(10 , 2000)]
        public double DefaultAmount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
