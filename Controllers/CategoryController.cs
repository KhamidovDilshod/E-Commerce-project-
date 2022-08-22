using E_Commerce.Api.Repository.Interface;

namespace E_Commerce.Api.Controllers;

public class CategoryController : BaseController
{
    private readonly ICategory _category;

    public CategoryController(ICategory category)
    {
        _category = category;
    }
}