using ApiCrudTest.Data;
using ApiCrudTest.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudTest.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public StoreRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            try
            {
                using var context = _dbContextFactory.CreateDbContext();
                return await context.Stores.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving stores", ex);
            }
        }

        public async Task<Store> GetStoreByIdAsync(int storeId)
        {
            try
            {
                using var context = _dbContextFactory.CreateDbContext();
                return await context.Stores.FindAsync(storeId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving store by ID", ex);
            }
        }

        public async Task AddStoreAsync(Store store)
        {
            try
            {
                using var context = _dbContextFactory.CreateDbContext();
                await context.Stores.AddAsync(store);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding store", ex);
            }
        }

        public async Task UpdateStoreAsync(Store store)
        {
            try
            {
                using var context = _dbContextFactory.CreateDbContext();
                context.Stores.Update(store);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating store", ex);
            }
        }

        public async Task DeleteStoreAsync(int storeId)
        {
            try
            {
                using var context = _dbContextFactory.CreateDbContext();
                var store = await context.Stores.FindAsync(storeId);
                if (store != null)
                {
                    context.Stores.Remove(store);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting store", ex);
            }
        }

    }
}
