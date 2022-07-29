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
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _ks;

        public KeepsController(KeepsService ks)
        {
            _ks = ks;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Keep>> CreateAsync([FromBody] Keep keepData)
        {
            try
            {

                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                keepData.CreatorId = userInfo?.Id;

                Keep newKeep = _ks.Create(keepData);
                newKeep.Creator = userInfo;
                return Ok(newKeep);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpGet]
        public ActionResult<List<Keep>> Get()
        {
            try
            {

                List<Keep> keep = _ks.Get();
                return Ok(keep);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

        [HttpGet("{id}")]
        public ActionResult<Keep> Get(int id)
        {

            try
            {
                Keep keep = _ks.Get(id);
                return Ok(keep);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id}")]
        [Authorize]

        public ActionResult<Keep> Edit([FromBody] Keep keep, int id)
        {
            try
            {
                keep.Id = id;
                Keep editKeep = _ks.Edit(keep);
                return Ok(editKeep);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpDelete("{id}")]
        [Authorize]

        public ActionResult<Keep> Delete(int id)
        {
            try
            {
                _ks.Delete(id);
                return Ok("Deleted");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }
    }
}