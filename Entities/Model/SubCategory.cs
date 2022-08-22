namespace E_Commerce.Api.Entities.Model;

public class SubCategory
{
    public SubCategory(int subCategoryId, List<string> subCategoryName)
    {
        SubCategoryId = subCategoryId;
        SubCategoryName = subCategoryName;
    }

    public int Id { get; set; }
    public int SubCategoryId { get; set; }
    public List<string> SubCategoryName { get; set; }
}