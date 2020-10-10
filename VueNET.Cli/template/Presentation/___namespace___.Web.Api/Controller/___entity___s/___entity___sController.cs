using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ___namespace___.Application.___entity___s;
using ___namespace___.Application.___entity___s.Dtos;
using ___namespace___.Utilities.Collections;

namespace ___namespace___.Web.Api.Controller.___entity___s
{
    [ApiController]
    [Route("api/[controller]")]
    public class ___entity___sController : ControllerBase
    {
        private readonly I___entity___sService ____entity___Service;

        public ___entity___sController(I___entity___sService ___entity___Service)
        {
            ____entity___Service = ___entity___Service;
        }

        [HttpGet]
        public async Task<ActionResult<IPagedList<___entity___Dto>>> GetAll([FromQuery] ___entity___ListInput input)
        {
            try
            {
                return Ok(await ____entity___Service.GetAllAsync(input));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<___entity___Dto>> GetById([FromQuery] int id)
        {
            try
            {
                return Ok(await ____entity___Service.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] ___entity___Dto ___entity___)
        {
            try
            {
                ____entity___Service.CreateAsync(___entity___);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] ___entity___Dto ___entity___)
        {
            try
            {
                ____entity___Service.Update(___entity___);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                ____entity___Service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
