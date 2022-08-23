namespace E_Commerce.Api.Entities.Products.Specifications;
#pragma warning disable
public class Colors
{
    public Colors(string color)
    {
        Color = color;
    }

    public Colors()
    {
    }

    public int Id { get; set; }
    public string Color { get; set; }
}