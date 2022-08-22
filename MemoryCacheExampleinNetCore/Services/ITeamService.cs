using MemoryCacheExampleinNetCore.Models;

namespace MemoryCacheExampleinNetCore.Services
{
    public interface ITeamService
    {
        List<Player> GetPlayers();

    }
}
