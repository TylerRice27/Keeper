using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
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

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                vaultData.CreatorId = userInfo?.Id;
                Vault newVault = _vs.Create(vaultData);
                // This line sent my creator.Data back has an Object
                // To make my schema model happy
                newVault.Creator = userInfo;
                return Ok(newVault);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);


            }

        }

        [HttpGet("{id}")]
        public ActionResult<Vault> Get(int id)
        {

            try
            {
                Vault vault = _vs.Get(id);
                return Ok(vault);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id}")]
        [Authorize]

        public ActionResult<Vault> Edit([FromBody] Vault vault, int id)
        {
            try
            {
                vault.Id = id;
                Vault editVault = _vs.Edit(vault);
                return Ok(editVault);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        [Authorize]

        public ActionResult<Vault> Delete(int id)
        {
            try
            {
                _vs.Delete(id);
                return Ok("Deleted Vault");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]

        public ActionResult<List<Vault>> GetKeeps(int id)
        {
            try
            {
                List<VaultKeepViewModel> keeps = _vks.GetByVaultId(id);
                return Ok(keeps);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}