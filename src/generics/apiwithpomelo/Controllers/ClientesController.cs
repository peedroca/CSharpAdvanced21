using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiwithpomelo.Entities;
using apiwithpomelo.Models;
using apiwithpomelo.Repositories;
using apiwithpomelo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiwithpomelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente) 
        {
            try
            {
                return Created($"Cliente/{cliente.Id}", _service.Create(cliente));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Cliente cliente) 
        {
            try
            {
                return Ok(_service.Update(cliente));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
