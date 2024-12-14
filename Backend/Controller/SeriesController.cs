using System;
using Backend.Data;
using Backend.Dtos.Serie;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;

[Route("api/series")]
[ApiController]

public class SeriesController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IsSeriesRepository _repo;
    public SeriesController(ApplicationContext context, IsSeriesRepository repo)
    {
        _context = context;
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var series = await _repo.GetAllAsync(query);
        var seriesDto = series.Select(s => s.ToSeriesDto());

        return Ok(series);
    }

    [HttpGet("{seriesId:int}")]
    public async Task<ActionResult> GetId([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var series = await _repo.GetIdAsync(id);

        if (series == null)
        {
            return NotFound();
        }

        return Ok(series.ToSeriesDto());
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateSeriesRequestDto seriesDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var seriesModel = seriesDto.ToSeriesFromCreateDto();
        
        await _repo.CreateAsync(seriesModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetId), new {id = seriesModel.IdSeries}, seriesModel.ToSeriesDto());
    }

    [HttpPut("{seriesId:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateSeriesRequestDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var seriesModel = await _repo.UpdateAsync(id, updateDto);

        if (seriesModel == null)
        {
            return NotFound();
        }

        await _context.SaveChangesAsync();

        return Ok(seriesModel.ToSeriesDto());
    }

    [HttpDelete]
    [Route("{seriesId:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var seriesModel = await _repo.DeleteAsync(id);

        if (seriesModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
