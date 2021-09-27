﻿using System.Collections.Generic;
using apiwithpomelo.Models;
using apiwithpomelo.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiwithpomelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
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

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var cliente = _service.Get(id);
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
