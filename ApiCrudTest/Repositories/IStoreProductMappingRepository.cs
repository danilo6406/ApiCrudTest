using ApiCrudTest.Models.DbModels;

namespace ApiCrudTest.Repositories
{
    public interface IStoreProductMappingRepository
    {
        Task<IEnumerable<StoreProductMapping>> GetAllMappingsAsync();
        Task<StoreProductMapping> GetMappingByIdAsync(int mappingId);
        Task AddMappingAsync(StoreProductMapping mapping);
        Task UpdateMappingAsync(StoreProductMapping mapping);
        Task DeleteMappingAsync(int mappingId);
    }
}
