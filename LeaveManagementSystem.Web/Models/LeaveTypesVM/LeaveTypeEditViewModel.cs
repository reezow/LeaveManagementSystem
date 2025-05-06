using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypesVM
{
    public class LeaveTypeEditViewModel
    {
        public int Id { get; set; }

        [Length(4, 150, ErrorMessage = "You have violated the length requirements")]
        public required string Name { get; set; }

        [Display(Name = "Number of Days")]
        [Required]
        [Range(1, 90)]
        public int NumberOfDays { get; set; }
    }
}
