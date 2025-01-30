using System.Linq.Expressions;
using BusinessX_Data.Contexts;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Repositorys;

public class ContactRepository(DataContext context) : BaseRepository<ContactEntity>(context), IContactRepository
{
    private readonly DataContext _context = context;

    public async Task<ContactEntity?> GetContactWithCustomersAsync(Expression<Func<ContactEntity, bool>> expression)
    {
        if (expression == null)
            return null;

        var contact = await _context.Contacts.Include(c => c.Customers).FirstOrDefaultAsync(expression);
        return contact;
    }
}
