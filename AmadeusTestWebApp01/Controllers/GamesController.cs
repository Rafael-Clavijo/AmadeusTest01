using AmadeusTestWebApp01.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmadeusTestWebApp01.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameContext _dbContext;

        public GamesController(GameContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// GET
        /// api/Games
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            if (_dbContext.Games == null)
                return NotFound();
            return await _dbContext.Games.ToListAsync();
        }

        /// <summary>
        /// GET
        /// api/Games/{id}
        /// </summary>
        /// <param name="id">unique identifier of the game to get</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            if (_dbContext.Games == null)
                return NotFound();
            var game = await _dbContext.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            return game;
        }

        /// <summary>
        /// POST
        /// api/Games
        /// </summary>
        /// <param name="game">data of the new game to add, 'id' field is ignored</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _dbContext.Games.Add(game);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        /// <summary>
        /// PUT
        /// api/Games/{id}
        /// </summary>
        /// <param name="id">unique identifier of the game to change</param>
        /// <param name="game">updated data of the game to change</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
                return BadRequest();
            _dbContext.Entry(game).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(game.Id))
                    return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (_dbContext.Games == null)
                return NotFound();

            var game = await _dbContext.Games.FindAsync(id);
            if(game == null) 
                return NotFound();

            _dbContext.Games.Remove(game);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Checks if a given id corresponds to any game in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool GameExists(long id)
        {
            return (_dbContext.Games?.Any(x => x.Id == id)).GetValueOrDefault();
        }

    }
}
