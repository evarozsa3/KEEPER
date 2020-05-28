using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<VaultKeep> Get(string userId)
    {
      return _repo.Get(userId);
    }


    public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId, userId);
    }

    public VaultKeep GetOne(int id)
    {
      VaultKeep foundVaultKeep = _repo.GetOne(id);
      if (foundVaultKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVaultKeep;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep, string userId)
    {
      return _repo.Create(newVaultKeep, userId);
    }

    internal string Delete(int id, string userId)
    {
      VaultKeep foundVaultKeep = GetOne(id);
      if (foundVaultKeep.UserId != userId)
      {
        throw new Exception("sorry cant touch this.. duh nah nah nah");
      }
      if (_repo.Delete(id, userId))
      {
        return "deleted";
      }
      throw new Exception("opps something went wrong");
    }
  }
}