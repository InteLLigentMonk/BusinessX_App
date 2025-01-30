using System.Linq.Expressions;
using BusinessX_Data.Entities;

namespace BusinessX_Data.Interfaces;

public interface IContactRepository : IBaseRepository<ContactEntity>
{
    Task<ContactEntity?> GetContactWithCustomersAsync(Expression<Func<ContactEntity, bool>> expression);
}