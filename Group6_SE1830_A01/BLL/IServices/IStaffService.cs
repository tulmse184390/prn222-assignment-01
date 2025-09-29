using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface IStaffService
    {
        Task<StaffInfo?> Login(LoginStaff loginStaff);
    }
}
