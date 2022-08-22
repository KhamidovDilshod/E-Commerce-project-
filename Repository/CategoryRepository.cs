using E_Commerce.Api.Entities;
using E_Commerce.Api.Repository.Interface;

namespace E_Commerce.Api.Repository;

public class CategoryRepository : ICategory
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext _context)
    {
        this._context = _context;
    }
}