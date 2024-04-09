using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<PositionController> _logger;

        public PositionController(ClinicDbContext context, ILogger<PositionController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdatePositions(PositionUpdateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid position update request.");
            }

            try
            {
                // Update positions for postes
                foreach (var posteUpdate in request.Postes ?? Enumerable.Empty<PosteUpdateRequest>())
                {
                    var poste = _context.Postes?.FirstOrDefault(p => p.PosteId == posteUpdate.Id);
                    if (poste != null)
                    {
                        poste.PositionX = posteUpdate.PositionX;
                        poste.PositionY = posteUpdate.PositionY;
                        _context.Entry(poste).State = EntityState.Modified;
                    }
                }

                // Update positions for repos
                foreach (var repoUpdate in request.Repos ?? Enumerable.Empty<RepoUpdateRequest>())
                {
                    var repo = _context.Repos?.FirstOrDefault(r => r.ReposId == repoUpdate.Id);
                    if (repo != null)
                    {
                        repo.PositionX = repoUpdate.PositionX;
                        repo.PositionY = repoUpdate.PositionY;
                        _context.Entry(repo).State = EntityState.Modified;
                    }
                }

                // Update positions for supplements
                foreach (var supplementUpdate in request.Supplements ?? Enumerable.Empty<SupplementUpdateRequest>())
                {
                    var supplement = _context.Supplements?.FirstOrDefault(s => s.SupplementId == supplementUpdate.Id);
                    if (supplement != null)
                    {
                        supplement.PositionX = supplementUpdate.PositionX;
                        supplement.PositionY = supplementUpdate.PositionY;
                        _context.Entry(supplement).State = EntityState.Modified;
                    }
                }

                _context.SaveChanges();

                return Ok("Positions updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating positions.");
                return StatusCode(500, "An error occurred while updating positions: " + ex.Message);
            }
        }

    }


}
