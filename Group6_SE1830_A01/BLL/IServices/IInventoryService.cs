using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.IServices
{
    public interface IInventoryService
    {
        Task<ICollection<ViewInventory>> GetInventory();
    }
}
