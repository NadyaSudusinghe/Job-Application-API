using JobTrackerAPI.Data;
using JobTrackerAPI.Models.Domain;
using JobTrackerAPI.Models.DTO;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController(JobTrackerDbContext context) : ControllerBase
    {
        private readonly JobTrackerDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<JobApplication>>> GetApplications()
        {
            return Ok(await _context.JobApplications.ToListAsync());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<JobApplication>> GetApplicationById(Guid id)
        {
            var application = await _context.JobApplications.FindAsync(id);
            if(application == null)
                return NotFound();

            var response = application.Adapt<JobApplicationResponse>();
            return Ok(application);
        }

        [HttpPost]
        public async Task<ActionResult<JobApplication>> AddApplication(JobApplication application)
        {
            if(application is null)
            {
                return BadRequest();
            }

            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApplicationById), new { id = application.Id }, application);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateApplication(Guid id, JobApplication updatedApplication)
        {
            var application = await _context.JobApplications.FindAsync(id);
            if (application == null)
                return NotFound();

            application.CompanyName = updatedApplication.CompanyName;
            application.Position = updatedApplication.Position;
            application.AppliedDate = updatedApplication.AppliedDate;
            application.Notes = updatedApplication.Notes;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteApplication(Guid id)
        {
            var application = await _context.JobApplications.FindAsync(id);
            if(application == null)
            {
                return NotFound();
            }

            _context.JobApplications.Remove(application);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
