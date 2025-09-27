using BLL.IServices;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepo _modelRepo;

        public ModelService(IModelRepo modelRepo)
        {
            _modelRepo = modelRepo;
        }

        public async Task<ICollection<Model>> GetAllModels()
        {
            var models = await _modelRepo.GetAllModels();
            return models;
        }

        public async Task<Model?> GetModelById(int id)
        {
            return await _modelRepo.GetModelById(id);
        }

        public async Task<int> CreateModel(Model model)
        {
            var created = await _modelRepo.AddAsync(model);
            await _modelRepo.SaveAsync();
            return created.ModelId;
        }

        public async Task UpdateModel(Model model)
        {
            _modelRepo.Update(model);
            await _modelRepo.SaveAsync();
        }

        public async Task DeleteModel(int id)
        {
            await _modelRepo.DeleteModel(id);
        }
    }
}
