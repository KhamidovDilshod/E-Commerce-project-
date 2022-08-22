using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Entities.Products;
using E_Commerce.Api.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers;

public class ProductController : BaseController
{
    private readonly IProduct _productRepo;

    public ProductController(IProduct productRepo)
    {
        _productRepo = productRepo;
    }

    [Authorize]
    [HttpGet("laptop/{id}")]
    public async Task<ActionResult<BaseLaptopDto>> GetMacById(int id)
    {
        return await _productRepo.GetById(id);
    }

    [HttpGet("laptop/color={colorId}&id={productId}")]
    public async Task<ActionResult<BaseLaptop>> GetMacByColor(int colorId, int productId)
    {
        var result = await _productRepo.GetByColorId(colorId, productId);
        return Ok(result);
    }

    [HttpPost("laptop/add")]
    public async Task<ActionResult<string>> AddProduct()
    {
        return Ok("CVFDd");
    }
}