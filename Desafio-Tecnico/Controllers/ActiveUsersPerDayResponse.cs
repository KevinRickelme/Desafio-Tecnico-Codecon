
namespace Desafio_Tecnico.Controllers
{
    internal class ActiveUsersPerDayResponse
    {
        public ActiveUsersPerDayResponse()
        {
        }

        public DateTime timestamp { get; set; }
        public int execution_time_ms { get; set; }
        public List<ActiveUsersPerDay> data { get; set; }
    }
}