namespace Desafio_Tecnico.Models
{
    public class UsersResponse
    {
        string message { get; set; }
        public int userCount { get; set; }
        public DateTime timestamp { get; set; }
        public int execution_time_ms { get; set; }
    }

}
