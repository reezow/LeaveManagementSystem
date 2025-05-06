using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypesVM
{
    public class LeaveTypeReadOnlyViewModel
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? Name { get; set; }

        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
    }
}
