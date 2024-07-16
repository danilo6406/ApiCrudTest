using ApiCrudTest.Data;
using ApiCrudTest.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace ApiCrudTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory _context;

        public ProductRepository(IDbContextFactory dbContextFactory)
        {
            _context = dbContextFactory;
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName)
        {
            try
            {
                using var context = _context.CreateDbContext();
                //return await context.Products.FirstOrDefaultAsync(e => e.ProductName == productName);
                return await context.Products.Where(e => e.ProductName.Contains(productName)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by name", ex);
            }
           
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                using var context = _context.CreateDbContext();
                return await context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products", ex);
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                return await context.Products.FindAsync(productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by ID", ex);
            }
        }

        public async Task AddProductAsync(Product product)
        {
            try
            {
                using var context = _context.CreateDbContext();
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product", ex);
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                using var context = _context.CreateDbContext();
                context.Products.Update(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product", ex);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var product = await context.Products.FindAsync(productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product", ex);
            }
        }

    }
}
