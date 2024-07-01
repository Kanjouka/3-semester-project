using Microsoft.AspNetCore.Mvc;
using Scheduler.Interfaces;
using Schedular.WebApi.DTO;

using Scheduler.Interfaces;

using Scheduler.Model;
using Scheduler.WebApi.DTO;

namespace Scheduler.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private IProjectDao<Project> _ProjectDao;

        public ProjectsController(IProjectDao<Project> projectDao) => _ProjectDao = projectDao;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjectsAsync()
        {
            IEnumerable<Project> projects = await _ProjectDao.GetAllAsync();
            IEnumerable<ProjectDTO> projectDTOs = projects.Select(projects => Mapper.ProjectToProjectDTO(projects)).ToList();
            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }
    }
}