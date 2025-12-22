using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebApi.Data;
using ProjetoWebApi.Models;

namespace ProjetoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;

        public PersonagensController(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appDbcontext.DBZ.Add(personagem);
            await _appDbcontext.SaveChangesAsync();
            return Created("Personagem adicionado com sucesso!", personagem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
        {
            var personagens = await _appDbcontext.DBZ.ToListAsync();
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetPersonagemId(int id)
        {
            var personagem = await _appDbcontext.DBZ.FindAsync(id);
            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }
            return Ok(personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
        {
            var personagemExistente = await _appDbcontext.DBZ.FindAsync(id);

            if (personagemExistente == null)
            {
                return NotFound("Personagem não encontrado");
            }

            _appDbcontext.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);
            await _appDbcontext.SaveChangesAsync();
            return StatusCode(201, personagemExistente);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _appDbcontext.DBZ.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }

            _appDbcontext.DBZ.Remove(personagem);
            await _appDbcontext.SaveChangesAsync();
            return Ok("Personagem excluído com sucesso!");
        }

    }
}