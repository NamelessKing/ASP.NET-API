﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aspnet.API.Tutorial.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}")] // "{id:int}" work only if id is int
        public IActionResult Get(int id,string query)
        {
            return Ok(new Value { Id = id, Text = "value " + id });
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get",new {id = value.Id },value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
        }
    }

    public class Value
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Text { get; set; }
    }

}
