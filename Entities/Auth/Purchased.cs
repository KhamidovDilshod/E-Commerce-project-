namespace E_Commerce.Api.Entities.Auth;

#pragma warning disable

public class Purchased
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string Date { get; set; }
}