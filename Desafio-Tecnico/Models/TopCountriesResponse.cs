namespace Desafio_Tecnico.Models
{
    public class TopCountriesResponse
    {
        public DateTime timestamp { get; set; }
        public int execution_time_ms { get; set; }
        public List<Pais> countries { get; set; }
    }
}

