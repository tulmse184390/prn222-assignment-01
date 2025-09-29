using AutoMapper;
using BLL.BusinessObjects;
using BLL.IServices;
using DAL.IRepository;

namespace BLL.Services
{
    public class StaffService : IStaffService
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepo _staffRepo;

        public StaffService(IMapper mapper, IStaffRepo staffRepo)
        {
            _mapper = mapper;
            _staffRepo = staffRepo;
        }

        public async Task<StaffInfo?> Login(LoginStaff loginStaff)
        {
            var staff = await _staffRepo.GetStaffByEmail(loginStaff.Email);

            if (staff == null || staff.Password != loginStaff.Password)
            {
                return null;
            }

            return _mapper.Map<StaffInfo>(staff);
        }
    }
}
