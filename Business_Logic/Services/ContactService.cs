using Business_Logic.Dtos;
using Business_Logic.Factorys;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Business_Logic.Interfaces;
using System.Linq.Expressions;


namespace Business_Logic.Services;

public class ContactService(IContactRepository repository) : BaseService<ContactEntity, Contact, ContactRegistrationForm, IContactRepository>(repository), IContactService
{
    protected override Contact CreateModel(ContactEntity entity) => ContactFactory.Create(entity);
    protected override ContactEntity CreateEntity(ContactRegistrationForm form) => ContactFactory.Create(form);
    protected override ContactEntity CreateEntity(Contact model) => ContactFactory.Create(model);


    public async Task<Contact> GetContactWithCustomersAsync(Expression<Func<ContactEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        var entity = await _repository.GetContactWithCustomersAsync(expression);
        if (entity == null)
            return null!;

        return ContactFactory.Create(entity);
    }
}
