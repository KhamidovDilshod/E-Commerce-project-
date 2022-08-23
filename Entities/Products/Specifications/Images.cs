namespace E_Commerce.Api.Entities.Products.Specifications;

public class Images
{
    public Images(string path)
    {
        Path = path;
    }

    public Images()
    {
    }

    public int Id { get; set; }
    public string Path { get; set; }
}