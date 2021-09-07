using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Contractor> Get()
    {
      string sql = "SELECT * FROM contractors";
      return _db.Query<Contractor>(sql).ToList();
    }

    internal Contractor Get(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal Contractor Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractors
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
      newContractor.Id = _db.ExecuteScalar<int>(sql, newContractor);
      return newContractor;
    }

    internal Contractor Update(Contractor updatedContractor)
    {
      string sql = @"
        UPDATE contractors
        SET
            name = @Name
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedContractor);
      return updatedContractor;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

  }
}