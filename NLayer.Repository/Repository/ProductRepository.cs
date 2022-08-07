using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsWithCategoryAsync()
    {
        return await _dbSet.Include(x => x.Category).ToListAsync();
    }
}
