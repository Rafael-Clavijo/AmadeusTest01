using Microsoft.EntityFrameworkCore;

namespace AmadeusTestWebApp01.Models
{
    public class GameContext : DbContext, IGameContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } = null!;

    }
}
