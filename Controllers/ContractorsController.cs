using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _contractorsService;

    public ContractorsController(ContractorsService contractorsService)
    {
      _contractorsService = contractorsService;
    }

    [HttpGet]
    public ActionResult<List<Contractor>> Get()
    {
      try
      {
        List<Contractor> contractors = _contractorsService.Get();
        return Ok(contractors);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        Contractor contractor = _contractorsService.Get(id);
        return Ok(contractor);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
      try
      {
        Contractor created = _contractorsService.Create(newContractor);
        return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit([FromBody] Contractor updatedContractor, int id)
    {
      try
      {
        updatedContractor.Id = id;
        Contractor artist = _contractorsService.Edit(updatedContractor);
        return Ok(artist);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Contractor> Delete(int id)
    {
      try
      {
         _contractorsService.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }




  }
}