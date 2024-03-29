using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Keeper.Models;
using Keeper.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        private readonly VaultsService _vs;

        public AccountController(AccountService accountService, VaultsService vs)
        {
            _accountService = accountService;
            _vs = vs;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("vaults")]
        [Authorize]

        public async Task<ActionResult<List<Vault>>> GetMyVaults()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Vault> vaults = _vs.GetMyVaults(userInfo.Id);
                return Ok(vaults);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }




        [HttpPut]
        [Authorize]

        public async Task<ActionResult<Account>> EditAccount([FromBody] Account editData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

                Account editAccount = _accountService.Edit(editData, editData.Email);
                return Ok(editAccount);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }



}