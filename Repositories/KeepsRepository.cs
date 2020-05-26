using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      string sql = "SELECT * FROM Keeps WHERE userId = @UserId;";
      return _db.Query<Keep>(sql, new { userId });
    }

    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id LIMIT 1";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal Keep Create(Keep KeepData)
    {
      string sql = @"
        INSERT INTO keeps
        (userId, name, description, img, isPrivate, views, shares, keeps)
        VALUES
        (@userId, @name, @description, @img, @isPrivate, @views, @shares, @keeps);
        SELECT LAST_INSERT_ID()";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
      return KeepData;
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}