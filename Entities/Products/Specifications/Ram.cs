namespace E_Commerce.Api.Entities.Products.Specifications;

#pragma warning disable

public class Ram
{
    public Ram(string memory)
    {
        Memory = memory;
    }

    public Ram()
    {
    }

    public int Id { get; set; }
    public string Memory { get; set; }
}