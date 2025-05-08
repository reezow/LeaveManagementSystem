using LeaveManagementSystem.Web.Models.LeaveTypesVM;

namespace LeaveManagementSystem.Web.Services
{
    public interface ILeaveTypeService
    {
        Task<bool> CheckIfLeaveTypeNameExistsAsync(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEditAsync(LeaveTypeEditViewModel leaveTypeEdit);
        Task Create(LeaveTypeCreateViewModel model);
        Task Edit(LeaveTypeEditViewModel model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyViewModel>> GetAllLeaveTypes();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}
