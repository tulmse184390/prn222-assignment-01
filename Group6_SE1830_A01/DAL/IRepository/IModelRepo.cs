using DAL.Entities;

namespace DAL.IRepository
{
    public interface IModelRepo : IRepository<Model>
    {
        Task<ICollection<Model>> GetAllModels();
        Task<Model?> GetModelById(int id);
        Task DeleteModel(int id);
    }
}
