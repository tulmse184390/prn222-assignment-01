using AutoMapper;
using BLL.BusinessObjects;
using BLL.IServices;
using DAL.Entities;
using DAL.IRepository;

namespace BLL.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IInventoryRepo _inventoryRepo;

        public InventoryService(IMapper mapper, IInventoryRepo inventoryRepo)
        {
            _mapper = mapper;
            _inventoryRepo = inventoryRepo;
        }

        public async Task<ICollection<ViewInventory>> GetInventory()
        {
            var inventory = await _inventoryRepo.GetInventory();

            return _mapper.Map<ICollection<ViewInventory>>(inventory);
        }
    }
}
