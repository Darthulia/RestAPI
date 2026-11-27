using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.DTOs;
using RestAPI.Models;

namespace RestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AdsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Ad>>> GetAll()
    {
        var ads = await context.Ads.ToListAsync();
        return Ok(ads);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ad>> GetById(int id)
    {
        var ad = await context.Ads.FindAsync(id);

        if (ad == null)
        {
            return NotFound();
        }

        return Ok(ad);
    }

    [HttpPost]
    public async Task<ActionResult<Ad>> Create(AdDto dto)
    {
        var ad = new Ad
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price!.Value,
            Category = dto.Category,
            Email = dto.Email,
            CreatedAt = DateTime.Now
        };

        context.Ads.Add(ad);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = ad.Id }, ad);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AdDto dto)
    {
        var ad = await context.Ads.FindAsync(id);

        if (ad == null)
        {
            return NotFound();
        }

        ad.Title = dto.Title;
        ad.Description = dto.Description;
        ad.Price = dto.Price!.Value;
        ad.Category = dto.Category;
        ad.Email = dto.Email;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, AdPatchDto dto)
    {
        var ad = await context.Ads.FindAsync(id);

        if (ad == null)
        {
            return NotFound();
        }

        if (dto.Title != null)
        {
            ad.Title = dto.Title;
        }

        if (dto.Description != null)
        {
            ad.Description = dto.Description;
        }

        if (dto.Price != null)
        {
            ad.Price = dto.Price.Value;
        }

        if (dto.Category != null)
        {
            ad.Category = dto.Category;
        }

        if (dto.Email != null)
        {
            ad.Email = dto.Email;
        }

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ad = await context.Ads.FindAsync(id);

        if (ad == null)
        {
            return NotFound();
        }

        context.Ads.Remove(ad);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
