﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_core_bootcamp_b1_ozgun.DTOs;
using net_core_bootcamp_b1_ozgun.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_ozgun.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody]BookAddDto model)
        {
            var result = _bookService.Add(model);
            return Ok(result);
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody]BookUpdateDto model)
        {
            var result = _bookService.Update(model);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([BindRequired]Guid id)
        {
            var result = _bookService.Delete(id);

            return Ok(result);
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(IList<BookGetDto>), 200)]
        public IActionResult Get()
        {
            var result = _bookService.Get();

            return Ok(result);
        }

    }
}
