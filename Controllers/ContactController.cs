using E_Commerce.Api.Repository.Interface;

namespace E_Commerce.Api.Controllers;

public class ContactController : BaseController
{
    private readonly IContact _contact;

    public ContactController(IContact contact)
    {
        _contact = contact;
    }
}