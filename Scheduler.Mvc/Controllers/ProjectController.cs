using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Scheduler.Interfaces;
using Scheduler.Mvc.Models;
using Scheduler.ApiClient.Dto;

namespace Scheduler.Mvc.Controllers;

//For future version
public class ProjectController : Controller

{
    private IProjectDao<ProjectDto> _projectDao;

    public ProjectController(IProjectDao<ProjectDto> projectDao)
    {
        _projectDao = projectDao;
    }

    public async Task<ActionResult> Index()
    {
        var projectDTOS = await _projectDao.GetAllAsync();
        var projects = projectDTOS.Select(project => Mapper.DtoProjectToProject(project));
        ViewBag.Projects = projects;
        if (projects == null)
        {
            return NotFound();
        }
        return View(projects);
    }

    public async Task<ActionResult> Details(int id)
    {
        var project = await _projectDao.GetByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }
}