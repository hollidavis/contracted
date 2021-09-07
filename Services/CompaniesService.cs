using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository _repo;

    public CompaniesService(CompaniesRepository repo)
    {
      _repo = repo;
    }
    internal List<Company> Get()
    {
      return _repo.Get();
    }
    internal Company Get(int id)
    {
      Company company = _repo.Get(id);
      if (company == null)
      {
        throw new Exception("Invalid Id");
      }
      return company;
    }

    internal Company Create(Company newCompany)
    {
      return _repo.Create(newCompany);
    }

    internal Company Edit(Company updatedCompany)
    {
      Company original = Get(updatedCompany.Id);
      updatedCompany.Name = updatedCompany.Name != null ? updatedCompany.Name : original.Name;
      return _repo.Update(updatedCompany);
    }

    internal void Delete(int id)
    {
      Company company = _repo.Get(id);
      if (company == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}