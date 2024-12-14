using System;
using Backend.Data;
using Backend.Dtos.Char;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;

[Route("api/char")]
[ApiController]

public class CharacterController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IsCharacterRepository _repo; 
    public CharacterController(ApplicationContext context, IsCharacterRepository repo)
    {
        _context = context;
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var chars = await _repo.GetAllAsync(query);
        var charDto = chars.Select(s => s.ToCharDto());

        return Ok(chars);
    }

    [HttpGet("{charId:int}")]
    public async Task<ActionResult> GetId([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var character = await _repo.GetIdAsync(id);

        if (character == null)
        {
            return NotFound();
        }

        return Ok(character.ToCharDto());
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCharRequestDto charDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var charModel = charDto.ToCharFromCreateDto();

        await _repo.CreateAsync(charModel);
        
        return CreatedAtAction(nameof(GetId), new {id = charModel.IdCharacter}, charModel.ToCharDto());
    }

    [HttpPut("{charId:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateCharRequestDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var charModel = await _repo.UpdateAsync(id, updateDto);

        if (charModel == null)
        {
            return NotFound();
        }

        await _context.SaveChangesAsync();
        
        return Ok(charModel.ToCharDto());
    }

    [HttpDelete]
    [Route("{charId:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var charModel = await _repo.DeleteAsync(id);

        if (charModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
