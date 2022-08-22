namespace E_Commerce.Api.Entities.DTO;

public class ContactDto
{
    public ContactDto(string message, string productName)
    {
        Message = message;
        ProductName = productName;
    }

    private string Message { get; }
    private string ProductName { get; }
}