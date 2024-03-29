﻿using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Tools.PdfDomainObjects;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly ICompetitorService _competitorService;

        public CompetitorController(ICompetitorService competitorService)
        {
            _competitorService = competitorService ?? throw new System.ArgumentNullException(nameof(competitorService));
        }

        [HttpGet("pdf")]
        public async Task<ActionResult> GetPdf()
        {
            var competitions = await _competitorService.GetAllWithSex();
            var pdf = new CompetitorsListPdf();
            var stream = pdf.GetPdf(competitions);
            return File(stream, "application/pdf");
        }

        [HttpGet]
        public async Task<IEnumerable<Competitor>> Get()
        {
            return await _competitorService.GetAllWithSex();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competitor>> Get(int id)
        {
            var result = await _competitorService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Competitor>> Post([FromBody] Competitor competitor)
        {
            await _competitorService.Create(competitor);
            return Ok(competitor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Competitor competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest();
            }
            var currentItem = await _competitorService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(competitor);
            await _competitorService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _competitorService.Delete(id);
            return Ok();
        }
    }
}
