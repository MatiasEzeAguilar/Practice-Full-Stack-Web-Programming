using System;
using Backend.Data;
using Backend.Dtos.Auth;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;

[Route("api/author")]
[ApiController]

public class AuthorController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IsAuthorRepository _repo;
    public AuthorController(ApplicationContext context, IsAuthorRepository repo)
    {
        _context = context;
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var authors = await _repo.GetAllAsync(query);
        var authorDto = authors.Select(s => s.ToAuthorDto());

        return Ok(authors);
    }

    [HttpGet("{authorId:int}")]
    public async Task<ActionResult> GetId([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var author = await _repo.GetIdAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author.ToAuthorDto());
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateAuthorRequestDto authorDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var authorModel = authorDto.ToAuthorFromCreateDto();

        await _repo.CreateAsync(authorModel);
        
        return CreatedAtAction(nameof(GetId), new {id = authorModel.IdAuthor}, authorModel.ToAuthorDto());
    }

    [HttpPut("{authorId:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var authorModel = await _repo.UpdateAsync(id, updateDto);
        
        if (authorModel == null)
        {
            return NotFound();
        }

        await _context.SaveChangesAsync();

        return Ok(authorModel.ToAuthorDto());
    }

    [HttpDelete]
    [Route("{authorId:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var authorModel = await _repo.DeleteAsync(id);
        
        if (authorModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
