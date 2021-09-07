using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _jobsService;
        public JobsController(JobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet("/contractors/{id}/companies")]
        public ActionResult<List<Job>> GetCompaniesByContractorId(int contractorId)
        {
            try
            {
                List<Job> job = _jobsService.GetCompaniesByContractorId(contractorId);
                return Ok(job);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                 Job created = _jobsService.Create(newJob);
                 return Ok(created);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            try
            {
                _jobsService.Delete(id);
                return Ok("Successfully Deleted");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}