namespace Desafio_Tecnico.Models
{
    public class SuperUserResponse
    {
        public DateTime timestamp { get; set; }
        public int execution_time_ms { get; set; }
        public List<User> data { get; set; }
    }
}
