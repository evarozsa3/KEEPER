using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<VaultKeep> Get(string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE userid = @userId";
      return _db.Query<VaultKeep>(sql, new { userId });
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      string sql = @"INSERT INTO vaultkeeps
            (id, vaultId, keepId, userId)
            VALUES
            (@Id, @VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID()";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }
  }
}