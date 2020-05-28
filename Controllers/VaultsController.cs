using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    private readonly VaultKeepsService _vks;
    public VaultsController(VaultsService vs, VaultKeepsService vks)
    {
      _vs = vs;
      _vks = vks;
    }
    // [HttpGet]
    // public ActionResult<IEnumerable<Vault>> Get()
    // {
    //   try
    //   {
    //     return Ok(_vs.Get());
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   };
    // }

    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Vault>> GetVaultsByUserId()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("please log in for vaults sake");
        }
        string userId = user.Value;
        return Ok(_vs.GetByUserId(userId));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> GetById(int id)
    {
      try
      {
        return Ok(_vs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [Authorize]
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeepsByVaultId(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.GetKeepsByVaultId(id, userId));
        // return Ok(_vs.GetById(id));
        // TODO call to the vault keep service. pass it the vault id,
        // TODO vault keep service call vault keep repsitory, to get vaultkeepsbyvaultId.
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    // [Authorize]
    // [HttpGet("{vaultId, userId}")]
    // public ActionResult<VaultKeep> GetKeepsByVaultId(int vaultId, string userId)
    // {
    //   try
    //   {
    //     return Ok(_vks.GetKeepsByVaultId(vaultId, userId));
    //   }
    //   catch (System.Exception err)
    //   {
    //     return BadRequest(err.Message);
    //   }

    // }

    // [Authorize]
    // [HttpGet("{id}/keeps")]
    // public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeepsByVaultId(int id)
    // {
    //   try
    //   {
    //     return Ok(_vs.GetKeepsByVaultId(id));
    //   }
    //   catch (System.Exception err)
    //   {
    //     return BadRequest(err.Message);
    //   }
    // }

    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newVault.UserId = userId;
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Please log in to delete");
        }
        string userId = user.Value;
        return Ok(_vs.Delete(id, userId));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}