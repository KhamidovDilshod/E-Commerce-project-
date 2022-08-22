namespace E_Commerce.Api.Entities.Products.Specifications;

#pragma warning disable

public class ColorImages
{
    public ColorImages(int productId, string imagePath, int colorId)
    {
        ProductId = productId;
        ImagePath = imagePath;
        ColorId = colorId;
    }

    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImagePath { get; set; }
    public int ColorId { get; set; }
}