using System.Linq.Expressions;
using BusinessX_Data.Contexts;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Repositorys;

public class EmployeeRolesRepository(DataContext context) : BaseRepository<EmployeeRolesEntity>(context), IEmployeeRolesRepository
{
    private readonly DataContext _context = context;

    public async Task<EmployeeRolesEntity?> GetEmployeeRoleWithEmployeesAsync(Expression<Func<EmployeeRolesEntity, bool>> expression)
    {
        if (expression == null)
            return null;

        var EmployeeRole = await _context.EmployeeRoles.Include(c => c.Employees).FirstOrDefaultAsync(expression);
        return EmployeeRole;
    }
}

