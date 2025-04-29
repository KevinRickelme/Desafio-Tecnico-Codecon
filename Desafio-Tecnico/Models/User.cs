namespace Desafio_Tecnico.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public int score { get; set; }
        public bool ativo { get; set; }
        public string pais { get; set; }
        public Team? equipe { get; set; }

        public List<Log?>? logs { get; set; }
    }

    public class Team
    {
        public string nome { get; set; }
        public bool lider { get; set; }
        public List<Project?>? projetos { get; set; }

    }

    public class Project
    {
        public string nome { get; set; }
        public bool concluido { get; set; }
    }
    
    public class Log
    {
        public string data { get; set; }
        public string acao { get; set; }
    }

    public class Pais
    {
        public string country { get; set; }
        public int total { get; set; }
    }

}

