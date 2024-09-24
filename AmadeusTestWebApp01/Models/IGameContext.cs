using Microsoft.EntityFrameworkCore;

namespace AmadeusTestWebApp01.Models
{
    public interface IGameContext
    {
        public DbSet<Game> Games { get; set; }
    }
}
