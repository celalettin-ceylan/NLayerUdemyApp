using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Services;

namespace NLayer.API.Controllers;

public class ProductController : CustomBaseController
{
    private readonly IMapper _mapper;
    private readonly IProductService _service;

    public ProductController(IService<Product> service, IMapper mapper, IProductService productService)
    {
        _mapper = mapper;
        _service = productService;
    }

    [HttpGet("GetProductsWithCategoryAsync")]
    public async Task<IActionResult> GetProductsWithCategoryAsync() {
        return CreateActionResult(await _service.GetProductsWithCategoryAsync()); 
    }

    [HttpGet]
    public async Task<IActionResult> All() {
        var products = await _service.GetAllAysnc();
        var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
        return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
    }

    [HttpPost]
    public async Task<IActionResult> Save(ProductDto productDto)
    {
        var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
        var productsDto = _mapper.Map<ProductDto>(product);
        return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProductUpdateDto productDto)
    {
        await _service.UpdateAsync(_mapper.Map<Product>(productDto));
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var product = await _service.GetByIdAsync(id);
        await _service.RemoveAsync(product);
        var productDto = _mapper.Map<ProductDto>(product);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
    }
}
