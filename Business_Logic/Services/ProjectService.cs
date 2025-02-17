using Business_Logic.Dtos;
using Business_Logic.Factorys;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Business_Logic.Interfaces;
using BusinessX_Data.Dtos;
using System.Linq.Expressions;


namespace Business_Logic.Services;

public class ProjectService(IProjectRepository repository) : BaseService<ProjectEntity, Project, ProjectRegistrationForm, IProjectRepository>(repository), IProjectService
{
    public async Task<ProjectDetailsDto> GetProjectWithDetailsAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var dto = await _repository.GetProjectWithDetailsAsync(expression);
        return dto;
    }

    public async Task<IEnumerable<RecentProjectsDto>> GetRecentAsync()
    {
        var entity = await _repository.GetRecentAsync();
        return entity;
    }

    protected override Project CreateModel(ProjectEntity entity) => ProjectFactory.Create(entity);
    protected override ProjectEntity CreateEntity(ProjectRegistrationForm form) => ProjectFactory.Create(form);
    protected override ProjectEntity CreateEntity(Project model) => ProjectFactory.Create(model);

}
