using E_Commerce.Api.Entities.Products.Specifications;

namespace E_Commerce.Api.Entities.DTO;

public class BaseLaptopDto
{
    public string LaptopName { get; set; }
    public List<Colors> Colors { get; set; }
    public List<Ram> Rams { get; set; }
    public List<Display> Display { get; set; }
    public Specs Specs { get; set; }
    public List<Storage> Storage { get; set; }
    public List<Images> Images { get; set; }
    public List<ImgHelper>ColorImagesList { get; set; }
}

public class ImgHelper
{
    public ImgHelper(string img)
    {
        base64 = img;
    }
    public string base64 { get; set; }
}