using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category> GetSingleCategoryByIdWithProductAysnc(int CategoryId)
    {
        return await _dbSet.Include(x => x.Products).Where(x => x.Id == CategoryId).SingleOrDefaultAsync();
    }
}
