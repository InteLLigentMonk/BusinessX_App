using System.Linq.Expressions;
using BusinessX_Data.Contexts;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Repositorys;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeeEntity>(context), IEmployeeRepository
{
    private readonly DataContext _context = context;

    public async Task<EmployeeEntity?> GetEmployeeWithProjectsAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        if (expression == null)
            return null;

        var Employee = await _context.Employees.Include(c => c.Projects).FirstOrDefaultAsync(expression);
        return Employee;
    }
}
