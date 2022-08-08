using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class CategoryService : Service<Category>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryByIdWithProductAysnc(int CategoryId)
    {
        var category = await _categoryRepository.GetSingleCategoryByIdWithProductAysnc(CategoryId);
        var categoryDto = _mapper.Map<CategoryWithProductDto>(category);
        return CustomResponseDto<CategoryWithProductDto>.Success(200, categoryDto);
    }
}
