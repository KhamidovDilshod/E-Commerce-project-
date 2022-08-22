using E_Commerce.Api.Entities;
using E_Commerce.Api.Entities.DTO;
using E_Commerce.Api.Entities.Products;
using E_Commerce.Api.Entities.Products.Specifications;
using E_Commerce.Api.Repository.Interface;
using E_Commerce.Api.Utils;
using Microsoft.EntityFrameworkCore;
using static System.Int32;

#pragma warning disable

namespace E_Commerce.Api.Repository;

public class ProductRepository : IProduct
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<BaseLaptopDto> GetById(int id)
    {
        var result = await _context.Laptop
            .Where(lap => lap.Id == id).FirstAsync();
        return await DtoMapper(result);
    }

    public async Task<List<BaseLaptop>> GetAllMac()
    {
        var result = await _context.Laptop.ToListAsync();
        return result;
    }

    public async Task<BaseLaptopDto> GetByColorId(int colorId, int productId)
    {
        var result = await _context.Laptop.Where(l => l.Id == productId).FirstAsync();
        var dto = await DtoMapper(result);
        var found = await ImageByColorFinder(colorId);
        List<ImgHelper> im = new List<ImgHelper>();
        foreach (var img in found)
        {
            foreach (var p in img.ImagePath.Split("|"))
            {
                im.Add(new ImgHelper(await Util.ImageByPath(p)));
            }
        }

        dto.ColorImagesList = im;
        dto.Images = null;
        return dto;
    }

    private async Task<BaseLaptopDto> DtoMapper(BaseLaptop result)
    {
        var baseDto = new BaseLaptopDto();

        var color = new List<Colors>();
        var ram = new List<Ram>();
        var img = new List<Images>();
        var dis = new List<Display>();
        var sto = new List<Storage>();
        foreach (var c in result.ColorIds.Split(","))
        {
            color.Add(await ColorFinder(Parse(c)));
        }

        foreach (var r in result.RamIds.Split(","))
        {
            ram.Add(await RamFinder(Parse(r)));
        }

        foreach (var i in result.ImageIds.Split(","))
        {
            img.Add(await ImageFinder(Parse(i)));
        }

        foreach (var d in result.DisplayIds.Split(","))
        {
            dis.Add(await DisplayFinder(Parse(d)));
        }

        foreach (var d in result.StorageIds.Split(","))
        {
            sto.Add(await StorageFinder(Parse(d)));
        }

        baseDto.Colors = color;
        baseDto.Rams = ram;
        baseDto.Images = img;
        baseDto.Display = dis;
        baseDto.Storage = sto;
        baseDto.LaptopName = result.ProductName;

        return baseDto;
    }

    private async Task<Images> ImageFinder(int id)
    {
        var result = await _context.Images.Where(i => i.Id == id).FirstOrDefaultAsync();
        result.Path = Util.ImageRetrieve(result.Path);
        return result;
    }

    private async Task<Ram> RamFinder(int id)
    {
        var result = await _context.Ram.Where(i => i.Id == id).FirstOrDefaultAsync();
        return result;
    }

    private async Task<Colors> ColorFinder(int id)
    {
        var result = await _context.Colors.Where(i => i.Id == id).FirstOrDefaultAsync();
        return result;
    }

    private async Task<Display> DisplayFinder(int id)
    {
        var result = await _context.Display.Where(i => i.Id == id).FirstOrDefaultAsync();
        return result;
    }

    private async Task<Storage> StorageFinder(int id)
    {
        var result = await _context.Storage.Where(i => i.Id == id).FirstOrDefaultAsync();
        return result;
    }

    private async Task<List<ColorImages>> ImageByColorFinder(int id)
    {
        var result = await _context.ColorImages.Where(img => img.ProductId == id).ToListAsync();
        return result;
    }
}