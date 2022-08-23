using E_Commerce.Api.Entities.Products.Specifications;

namespace E_Commerce.Api.Entities.Products;

#pragma warning disable

public class BaseLaptop
{
    public BaseLaptop(Colors colors, Ram rams, Images images, Display display, Specs specs, Storage storage,
        string imageIds, string colorIds, string ramIds, string displayIds, string storageIds, string productName)
    {
        Colors = colors;
        Rams = rams;
        Images = images;
        Display = display;
        Specs = specs;
        Storage = storage;
        ImageIds = imageIds;
        ColorIds = colorIds;
        RamIds = ramIds;
        DisplayIds = displayIds;
        StorageIds = storageIds;
        ProductName = productName;
    }

    public BaseLaptop()
    {
    }


    public int Id { get; set; }
    public string ProductName { get; set; }
    public Colors Colors { get; set; }
    public Ram Rams { get; set; }
    public Images Images { get; set; }
    public Display Display { get; set; }
    public Specs Specs { get; set; }
    public Storage Storage { get; set; }

    public string ImageIds { get; set; }
    public string ColorIds { get; set; }
    public string RamIds { get; set; }
    public string DisplayIds { get; set; }
    public string StorageIds { get; set; }
}