namespace Desafio_Tecnico.Models
{
    public class TeamInsightsResponse
    {
        public DateTime timestamp { get; set; }
        public int execution_time_ms { get; set; }
        public List<TeamInsights> teams { get; set; }
    }

}
