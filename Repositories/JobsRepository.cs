using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Job Get(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }
    internal List<Job> GetCompaniesByContractorId(int contractorId)
    {
      string sql = "SELECT * FROM jobs WHERE contractorId = @contractorId";
      return _db.Query<Job>(sql).ToList();
    }
    internal Job Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (companyId, contractorId)
      VALUES
      (@CompanyId, @ContractorId);
      SELECT LAST_INSERT_ID();
      ";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}