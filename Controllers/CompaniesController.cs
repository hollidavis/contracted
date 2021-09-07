using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contracted.Models;
using contracted.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class CompaniesController : ControllerBase
  {
    private readonly CompaniesService _companiesService;

    public CompaniesController(CompaniesService companiesService)
    {
      _companiesService = companiesService;
    }

    [HttpGet]
    public ActionResult<List<Company>> Get()
    {
      try
      {
        List<Company> companies = _companiesService.Get();
        return Ok(companies);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Company> Get(int id)
    {
      try
      {
        Company company = _companiesService.Get(id);
        return Ok(company);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Company> Create([FromBody] Company newCompany)
    {
      try
      {
        Company created = _companiesService.Create(newCompany);
        return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Company> Edit([FromBody] Company updatedCompany, int id)
    {
      try
      {
        updatedCompany.Id = id;
        Company artist = _companiesService.Edit(updatedCompany);
        return Ok(artist);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Company> Delete(int id)
    {
      try
      {
         _companiesService.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }




  }
}