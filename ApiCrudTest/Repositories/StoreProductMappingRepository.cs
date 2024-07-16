using ApiCrudTest.Data;
using ApiCrudTest.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiCrudTest.Repositories
{
    public class StoreProductMappingRepository : IStoreProductMappingRepository
    {
        private readonly IDbContextFactory _context;

        public StoreProductMappingRepository(IDbContextFactory dbContextFactory)
        {
            _context = dbContextFactory;
        }

        public async Task<IEnumerable<StoreProductMapping>> GetAllMappingsAsync()
        {
            try
            {
                using var context = _context.CreateDbContext();
                return await context.StoreProductMappings
                    .Include(spm => spm.Store)
                    .Include(spm => spm.Product)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving mappings", ex);
            }
        }

        public async Task<StoreProductMapping> GetMappingByIdAsync(int mappingId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                return await context.StoreProductMappings
                    .Include(spm => spm.Store)
                    .Include(spm => spm.Product)
                    .FirstOrDefaultAsync(spm => spm.MappingID == mappingId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving mapping by ID", ex);
            }
        }

        public async Task AddMappingAsync(StoreProductMapping mapping)
        {
            try
            {
                using var context = _context.CreateDbContext();
                await context.StoreProductMappings.AddAsync(mapping);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding mapping", ex);
            }
        }

        public async Task UpdateMappingAsync(StoreProductMapping mapping)
        {
            try
            {
                using var context = _context.CreateDbContext();
                context.StoreProductMappings.Update(mapping);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating mapping", ex);
            }
        }

        public async Task DeleteMappingAsync(int mappingId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var mapping = await context.StoreProductMappings.FindAsync(mappingId);
                if (mapping != null)
                {
                    context.StoreProductMappings.Remove(mapping);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting mapping", ex);
            }
        }

    }
}
