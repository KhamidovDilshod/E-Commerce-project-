namespace E_Commerce.Api.Entities.Products.Specifications;

public class Display
{
    public Display(string resolution)
    {
        Resolution = resolution;
    }

    public Display()
    {
    }

    public int Id { get; set; }
    public string Resolution { get; set; }
}