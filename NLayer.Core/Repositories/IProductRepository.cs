using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Model;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repository;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithCategoryAsync();
}
