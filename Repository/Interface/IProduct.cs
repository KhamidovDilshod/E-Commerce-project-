using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Entities.Products;

namespace E_Commerce.Api.Repository.Interface;

public interface IProduct
{
    Task<BaseLaptopDto> GetById(int id);
    Task<List<BaseLaptop>> GetAllMac();
    Task<BaseLaptopDto> GetByColorId(int colorId,int productId);
}