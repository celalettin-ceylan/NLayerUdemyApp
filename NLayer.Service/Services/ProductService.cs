﻿using System;
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
using NLayer.Repository.Repository;

namespace NLayer.Service.Services;

public class ProductService : Service<Product>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork , IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync()
    {
        var product = await _productRepository.GetProductsWithCategoryAsync();
        var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(product);
        return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200,productsDto);
    }
}