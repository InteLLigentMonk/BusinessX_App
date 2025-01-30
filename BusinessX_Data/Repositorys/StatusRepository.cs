using BusinessX_Data.Contexts;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;

namespace BusinessX_Data.Repositorys;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context), IStatusRepository
{
    private readonly DataContext _context = context;
}
