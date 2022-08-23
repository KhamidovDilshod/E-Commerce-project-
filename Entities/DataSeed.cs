using E_Commerce.Api.Entities.Products;
using E_Commerce.Api.Entities.Products.Specifications;

namespace E_Commerce.Api.Entities;

public class DataSeed
{
    private readonly DataContext _context;

    public DataSeed(DataContext context)
    {
        _context = context;
    }

    private List<Colors> SeedColor()
    {
        return new List<Colors>
        {
            new("Black"),
            new("Space Gray"),
            new("Midnight"),
            new("Silver")
        };
    }

    private List<Display> SeedDisplay()
    {
        return new List<Display>
        {
            new("13 inch"),
            new("14 inch"),
            new("16 inch")
        };
    }

    private List<Images> SeedImages()
    {
        return new List<Images>
        {
            new("macbook.jpg"),
            new("macbook.jpg"),
            new("macbook.jpg"),
            new("macbook.jpg"),
            new("macbook.jpg")
        };
    }

    private List<Ram> SeedRam()
    {
        return new List<Ram>
        {
            new("16GB"),
            new("32GB"),
            new("64GB")
        };
    }

    private List<Specs> SeedSpecs()
    {
        return new List<Specs>
        {
            new()
        };
    }

    private List<Storage> SeedStorage()
    {
        return new List<Storage>
        {
            new("128GB"),
            new("256GB"),
            new("512GB"),
            new("1TB"),
            new("4TB"),
            new("8TB")
        };
    }

    private List<ColorImages> SeedCImages()
    {
        return new List<ColorImages>
        {
            new(1, @"C:\Users\user\Desktop\Images\macbook.jpg", 1),
            new(1, @"C:\Users\user\Desktop\Images\macbook.jpg", 2),
            new(1, @"C:\Users\user\Desktop\Images\macbook.jpg", 3),
            new(1, @"C:\Users\user\Desktop\Images\macbook.jpg", 4)
        };
    }

    private List<BaseLaptop> SeedLaptop()
    {
        return new List<BaseLaptop>
        {
            new(SeedColor()[0], SeedRam()[0], SeedImages()[0], SeedDisplay()[0], SeedSpecs()[0],
                SeedStorage()[0],
                "1,2,3,4,5", "1,2,3,4", "1,2,3", "1,2,3", "1,2,3,4,5,6", "Macbook pro 2022 16 inch")
        };
    }

    public async Task Handler()
    {
        if (!_context.Laptop.Any())
            foreach (var laptop in SeedLaptop())
                await _context.Laptop.AddAsync(laptop);

        if (!_context.Laptop.Any())
            foreach (var img in SeedCImages())
                await _context.ColorImages.AddAsync(img);

        if (!_context.Colors.Any())
            foreach (var color in SeedColor())
                await _context.Colors.AddAsync(color);

        if (!_context.Display.Any())
            foreach (var display in SeedDisplay())
                await _context.Display.AddAsync(display);

        if (!_context.Images.Any())
            foreach (var image in SeedImages())
                await _context.Images.AddAsync(image);

        if (!_context.Ram.Any())
            foreach (var ram in SeedRam())
                await _context.Ram.AddAsync(ram);

        if (!_context.Specifications.Any())
            foreach (var specs in SeedSpecs())
                await _context.Specifications.AddAsync(specs);

        if (!_context.Storage.Any())
            foreach (var storage in SeedStorage())
                await _context.Storage.AddAsync(storage);

        await _context.SaveChangesAsync();
    }
}