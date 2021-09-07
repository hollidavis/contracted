using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class CompaniesRepository
  {
    private readonly IDbConnection _db;

    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Company> Get()
    {
      string sql = "SELECT * FROM companies";
      return _db.Query<Company>(sql).ToList();
    }

    internal Company Get(int id)
    {
      string sql = "SELECT * FROM companies WHERE id = @id";
      return _db.QueryFirstOrDefault<Company>(sql, new { id });
    }

    internal Company Create(Company newCompany)
    {
      string sql = @"
      INSERT INTO companies
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
      newCompany.Id = _db.ExecuteScalar<int>(sql, newCompany);
      return newCompany;
    }

    internal Company Update(Company updatedCompany)
    {
      string sql = @"
        UPDATE companies
        SET
            name = @Name
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedCompany);
      return updatedCompany;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM companies WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

  }
}