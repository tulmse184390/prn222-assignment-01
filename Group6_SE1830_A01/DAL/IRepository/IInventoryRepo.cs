using DAL.Entities;

namespace DAL.IRepository
{
    public interface IInventoryRepo : IRepository<Inventory>
    {
        Task<ICollection<Inventory>> GetInventory();
        Task<int> GetTotalQuantity();
        Task<Inventory?> GetCar(int versionId, int colorId);
    }
}
