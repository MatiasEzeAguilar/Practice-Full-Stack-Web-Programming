using System;
using Backend.Data;
using Backend.Dtos.Prod;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Backend.Controller;

[Route("api/producer")]
[ApiController]

public class ProducerController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IsProducerRepository _repo;
    public ProducerController(ApplicationContext context, IsProducerRepository repo)
    {
        _context = context;
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var producers = await _repo.GetAllAsync(query);
        var producerDto = producers.Select(s => s.ToProducerDto());

        return Ok(producers);
    } 

    [HttpGet("{producerId:int}")]
    public async Task<ActionResult> GetId([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var producer = await _repo.GetIdAsync(id);

        if (producer == null)
        {
            return NotFound();
        }

        return Ok(producer.ToProducerDto());
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateProducerRequestDto producerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var producerModel = producerDto.ToProdFromCreateDto();
        
        await _repo.CreateAsync(producerModel);
        
        return CreatedAtAction(nameof(GetId), new {id = producerModel.IdProducer}, producerModel.ToProducerDto());
    }

    [HttpPut("{producerId:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateProdRequestDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var producerModel = await _repo.UpdateAsync(id, updateDto);

        if (producerModel == null)
        {
            return NotFound();
        }

        await _context.SaveChangesAsync();

        return Ok(producerModel.ToProducerDto());
    }

    [HttpDelete]
    [Route("{producerId:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var producerModel = await _repo.DeleteAsync(id);

        if (producerModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
