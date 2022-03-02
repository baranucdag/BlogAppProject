﻿using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private ITagService tagService;
        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;  
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = tagService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbytagid")]
        public IActionResult GetByTagId(int tagId)
        {
            var result = tagService.GetById(tagId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Tag tag)
        {
            var result = tagService.Add(tag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Tag tag)
        {
            var result = tagService.Delete(tag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Tag tag)
        {
            var result = tagService.Update(tag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}