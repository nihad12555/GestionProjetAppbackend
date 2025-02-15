using GestionProjetAppBack.Data;
using GestionProjetAppBack.Dtos.TacheDto;
using GestionProjetAppBack.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProjetAppBack.Controllers;

    [Route("api/taches")]
    [ApiController]
    public class TacheController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TacheController(ApplicationDbContext context)
        {
            _context = context;
        }

        //  Créer une tâche
    [HttpPost]
    public async Task<ActionResult<Tache>> CreateTache([FromBody] CreateTacheDTO tacheDto)
    {
        try
        {
            var tache = new Tache
            {
                Nom = tacheDto.Nom,
                Description = tacheDto.Description,
                EstTerminee = tacheDto.EstTerminee,
                DateLimite = tacheDto.DateLimite,
                Responsable = tacheDto.Responsable,
                ProjetId = tacheDto.ProjetId
            };

            _context.Taches.Add(tache);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTache), new { id = tache.Id }, tache);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(500, "Une erreur interne est survenue.");
        }
    }

    //  Récupérer une tâche par ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Tache>> GetTache(int id)
    {
        var tache = await _context.Taches.FindAsync(id);

        if (tache == null)
        {
            return NotFound();
        }

        return tache;
    }

    //  Modifier une tâche
    [HttpPut("{id}")]
    public async Task<IActionResult> ModifierTache(int id, [FromBody] CreateTacheDTO tacheDto)
    {
        var tache = await _context.Taches.FindAsync(id);
        if (tache == null)
        {
            return NotFound();
        }

        try
        {
            tache.Nom = tacheDto.Nom;
            tache.Description = tacheDto.Description;
            tache.EstTerminee = tacheDto.EstTerminee;
            tache.DateLimite = tacheDto.DateLimite;
            tache.Responsable = tacheDto.Responsable;
            tache.ProjetId = tacheDto.ProjetId;

            _context.Taches.Update(tache);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(500, "Une erreur interne est survenue.");
        }
    }


        [HttpDelete("{id}")]
        public async Task<IActionResult> SupprimerTache(int id)
        {
            var tache = await _context.Taches.FindAsync(id);
            if (tache == null) return NotFound();
        
            _context.Taches.Remove(tache);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

