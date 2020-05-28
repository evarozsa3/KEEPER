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

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    //Changed from <VaultKeepViewModel>
    {
      string sql = @"SELECT 
        k.*,
        vk.id as vaultKeepId
        FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId 
        WHERE (vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });
    }
    internal VaultKeep GetOne(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }
    internal VaultKeep Create(VaultKeep newVaultKeep, string userId)
    {
      string sql = @"INSERT INTO vaultkeeps
            (id, vaultId, keepId, userId)
            VALUES
            (@Id, @VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID()";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}