namespace E_Commerce.Api.Entities.Products.Specifications;

public class Storage
{
    public Storage(string memory)
    {
        Memory = memory;
    }

    public Storage()
    {
    }

    public int Id { get; set; }
    public string Memory { get; set; }
}