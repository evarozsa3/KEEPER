using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }

    public Vault GetById(int id)
    {
      Vault foundVault = _repo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("invalid id");
      }
      return foundVault;
    }

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal string Delete(int id, string userId)
    {
      Vault foundVault = GetById(id);
      if (foundVault.UserId != userId)
      {
        throw new Exception("You can only delete your own vaults");
      }
      if (_repo.Delete(id, userId))
      {
        return "Deleted";
      }
      throw new Exception("Deleted yeppers");
    }
  }
}