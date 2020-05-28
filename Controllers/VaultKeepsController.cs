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

namespace Keepr.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<VaultKeep>> Get()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in");
        }
        string userId = user.Value;
        return Ok(_vks.Get(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> GetOne(int id)
    {
      try
      {
        return Ok(_vks.GetOne(id));
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

    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newVaultKeep.UserId = userId;
        return Ok(_vks.Create(newVaultKeep, userId));
        // return Ok(_vks.GetKeepsByVaultId(id, userId));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
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
          throw new Exception("please log in to destroy!");
        }
        string userId = user.Value;
        return Ok(_vks.Delete(id, userId));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}