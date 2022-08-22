using E_Commerce.Api.Entities;
using E_Commerce.Api.Repository.Interface;

namespace E_Commerce.Api.Repository;

public class ContactRepository : IContact
{
    private readonly DataContext _context;

    public ContactRepository(DataContext context)
    {
        _context = context;
    }
}