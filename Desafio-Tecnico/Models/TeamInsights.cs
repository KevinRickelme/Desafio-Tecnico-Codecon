namespace Desafio_Tecnico.Models
{
    public class TeamInsights
    {
        public string team { get; set; }
        public int total_members { get; set; }
        public int leaders { get; set; }
        public int completed_projects { get; set; }
        public double active_percentage { get; set; }
    }
}