using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTOs;
using NLayer.Core.Model;

namespace NLayer.Core.Services;

public interface ICategoryService : IService<Category>
{
    Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryByIdWithProductAysnc(int CategoryId);
}
