using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;
    public JobsService(JobsRepository repo)
    {
        _repo = repo;
    }
    private Job Get(int id)
    {
      Job found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal List<Job> GetCompaniesByContractorId(int contractorId)
    {
      return _repo.GetCompaniesByContractorId(contractorId);
    }

    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }
    internal void Delete(int id)
    {
      Job job = _repo.Get(id);
      if (job == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}