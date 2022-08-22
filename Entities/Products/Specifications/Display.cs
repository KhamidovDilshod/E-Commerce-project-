namespace E_Commerce.Api.Entities.Products.Specifications;

public class Display
{
    public int Id { get; set; }
    public string Resolution { get; set; } 

    public Display( string resolution)
    {
        Resolution = resolution;
    }

    public Display()
    {
        
    }
}