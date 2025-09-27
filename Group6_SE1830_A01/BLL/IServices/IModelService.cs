using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BLL.IServices
{
    public interface IModelService
    {
        Task<ICollection<Model>> GetAllModels();
        Task<Model?> GetModelById(int id);
        Task<int> CreateModel(Model model);
        Task UpdateModel(Model model);
        Task DeleteModel(int id);
    }
}
