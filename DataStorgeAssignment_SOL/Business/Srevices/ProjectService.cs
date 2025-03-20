
using Business.Models;
using DataStorgeAssignment.Entities;
using DataStorgeAssignment.Repositories;
using static Azure.Core.HttpHeader;

namespace Business.Srevices;

public class ProjectService(ProjectRepository projectRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;


    public async Task<bool> CreateProjectAsync(ProjectModel project)
    {

        try
        {
            var ProjectEntity = new ProjectEntity
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Status = project.Status,
                Notes = project.Notes,

            };

            await _projectRepository.AddAsync(ProjectEntity);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }

    }


    public async Task<IEnumerable<ProjectEntity>?> GetProjectsAsync()
    {

        var projectEntities = await _projectRepository.GetAsync();

        if (projectEntities.Count() == 0)
        {
            return null;
        }

        var projects = new List<ProjectEntity>();
        foreach (var projectEntity in projectEntities)
        {
            projects.Add(new ProjectEntity
            {
                Id = projectEntity.Id,
                Title = projectEntity.Title,
                Description = projectEntity.Description,
                Status = projectEntity.Status,
                Notes = projectEntity.Notes,
            });
        }

        return projects;
    }

    public async Task<ProjectEntity>? GetProjectByIdAsync(int id)
    {

        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);

            if (projectEntity == null) { return null; }

            return projectEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }

    }


    public async Task<bool> UpdateProjectAsync(int id, ProjectModel project)
    {

        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == project.Id);

            if (projectEntity == null) { return false; }

            projectEntity.Title = project.Title;
            projectEntity.Description = project.Description;
            projectEntity.Status = project.Status;
            projectEntity.Notes = project.Notes;

            await _projectRepository.UpdateAsync(projectEntity);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }




    }

    public async Task<bool> DeleteProjectAsync(int id)
    {

        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);

            if (projectEntity == null) { return false; }

            await _projectRepository.RemoveAsync(projectEntity);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

}
