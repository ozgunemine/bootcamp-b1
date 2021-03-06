﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_core_bootcamp_b1_ozgun.DTOs;
using net_core_bootcamp_b1_ozgun.Services;
using System;
using System.Collections.Generic;

namespace net_core_bootcamp_b1_ozgun.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        ///  Git Example Changes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult Add([FromBody]ProductAddDto model)
        {
            var result = _productService.Add(model);

            return Ok(result);
        }

        /// <summary>
        ///  Git example master
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult Update([FromBody]ProductUpdateDto model)
        {
            var result = _productService.Update(model);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([BindRequired]Guid id)
        {
            var result = _productService.Delete(id);

            return Ok(result);
        }

        /// <summary>
        /// Get All Products
        /// </summary>        
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(IList<ProductGetDto>), 200)]
        public IActionResult Get()
        {
            var result = _productService.Get();

            return Ok(result);
        }
    }
}