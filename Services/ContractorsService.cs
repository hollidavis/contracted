using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;

    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }
    internal List<Contractor> Get()
    {
      return _repo.Get();
    }
    internal Contractor Get(int id)
    {
      Contractor contractor = _repo.Get(id);
      if (contractor == null)
      {
        throw new Exception("Invalid Id");
      }
      return contractor;
    }

    internal Contractor Create(Contractor newContractor)
    {
      return _repo.Create(newContractor);
    }

    internal Contractor Edit(Contractor updatedContractor)
    {
      Contractor original = Get(updatedContractor.Id);
      updatedContractor.Name = updatedContractor.Name != null ? updatedContractor.Name : original.Name;
      return _repo.Update(updatedContractor);
    }

    internal void Delete(int id)
    {
      Contractor contractor = _repo.Get(id);
      if (contractor == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}