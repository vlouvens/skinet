using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;

        }

        public async Task<Products> GetProductByIdAysnc(int id)
        {
            var product = await _context.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType).FirstOrDefaultAsync(p=>p.Id == id)
                 ?? throw new NotFoundException($"Le produit avec l'ID {id} n'a pas été trouvé.");
            return product;
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductType.ToListAsync();
        }
    }
}