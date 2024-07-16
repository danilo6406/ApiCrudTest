using ApiCrudTest.Models.DbModels;

namespace ApiCrudTest.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(int storeId);
        Task AddStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(int storeId);
    }
}
