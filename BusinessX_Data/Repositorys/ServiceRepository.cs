using System.Linq.Expressions;
using BusinessX_Data.Contexts;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Repositorys;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
    private readonly DataContext _context = context;

    public async Task<ServiceEntity?> GetServiceWithProjectsAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        if (expression == null)
            return null;

        var Service = await _context.Services.Include(c => c.Projects).FirstOrDefaultAsync(expression);
        return Service;
    }
}
