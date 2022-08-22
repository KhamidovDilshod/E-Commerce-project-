namespace E_Commerce.Api.Entities.Model;

#pragma warning disable

public class Categories
{
    public Categories(string categoryName, int count, int categoryId, string image)
    {
        Image = image;
        Count = count;
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int Count { get; set; }
    public string Image { get; set; }
}