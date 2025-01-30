using System.Linq.Expressions;
using BusinessX_Data.Contexts;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Repositorys;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    private readonly DataContext _context = context;

    public async Task<CustomerEntity?> GetCustomerWithProjectsAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return null;

        var contact = await _context.Customers.Include(c => c.Projects).FirstOrDefaultAsync(expression);
        return contact;
    }
}
