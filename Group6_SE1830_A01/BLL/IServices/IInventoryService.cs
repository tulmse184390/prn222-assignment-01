using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.IServices
{
    public interface IInventoryService
    {
        Task<ICollection<ViewInventory>> GetInventory();
        Task<int> GetTotalInventory();  
        Task UpdateAllQuantities(List<UpdateInventoryQuantity> updates);
    }
}
