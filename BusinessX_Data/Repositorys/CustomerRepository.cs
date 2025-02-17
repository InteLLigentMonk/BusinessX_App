using System.Diagnostics;
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

    public override async Task<CustomerEntity> UpdateAsync(Expression<Func<CustomerEntity, bool>> expression, CustomerEntity updatedEntity)
    {
        if (updatedEntity == null || expression == null)
            return null!;

        try
        {
            var existingEntity = await _context.Customers.FirstOrDefaultAsync(expression);
            if (existingEntity == null)
                return null!;

            // Remove the existing entity
            _context.Customers.Remove(existingEntity);
            await _context.SaveChangesAsync();

            // Add the updated entity
            await _context.Customers.AddAsync(updatedEntity);
            await _context.SaveChangesAsync();

            return updatedEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating {nameof(CustomerEntity)} entity :: {ex.Message}");
            if (ex.InnerException != null)
            {
                Debug.WriteLine($"Inner exception :: {ex.InnerException.Message}");
            }
            return null!;
        }
    }
}
