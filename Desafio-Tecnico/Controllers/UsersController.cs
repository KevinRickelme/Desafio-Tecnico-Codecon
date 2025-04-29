using Desafio_Tecnico.Models;
using Desafio_Tecnico.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Tecnico.Controllers
{
    [ApiController]
    [Route("/")]
    public class UsersController(IJsonUsersService jsonUsersService) : ControllerBase
    {
        private readonly IJsonUsersService _jsonUsersService = jsonUsersService;

        //fazer upload de um arquivo JSON
        [HttpPost("users", Name = "users")]
        public IActionResult users(IFormFile file)
        {
            var startTime = DateTime.Now;
            try
            {
                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    var json = stream.ReadToEnd();
                    _jsonUsersService.StoreJson(json);
                }
                UsersResponse ur = new()
                {
                    userCount = _jsonUsersService.GetJson().Count,
                    timestamp = startTime,
                    execution_time_ms = (int)(DateTime.Now - startTime).TotalMilliseconds,
                };
                return Ok(ur);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error storing JSON: {ex.Message}");
            }
        }




        //[HttpPost("users", Name = "users")]
        //public IActionResult users(List<User> Users)
        //{
        //    var startTime = DateTime.Now;
        //    try
        //    {
        //        _jsonUsersService.StoreUsers(Users);
        //        UsersResponse ur = new()
        //        {
        //            userCount = Users.Count,
        //            timestamp = startTime,
        //            execution_time_ms = (int)(DateTime.Now - startTime).TotalMilliseconds,
        //        };
        //        return Ok(ur);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error storing JSON: {ex.Message}");
        //    }
        //}

        [HttpGet("superusers", Name = "superusers")]
        public IActionResult superUsers()
        {
            var startTime = DateTime.Now;
            try
            {
                var users = _jsonUsersService.GetJson();
                var superUsers = users.Where(u => u.score > 900 && u.ativo == true).ToList();
                SuperUserResponse sur = new()
                {
                    timestamp = startTime,
                    execution_time_ms = (int)(DateTime.Now - startTime).TotalMilliseconds,
                    data = superUsers
                };
                return Ok(sur);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving superusers: {ex.Message}");
            }
        }

        [HttpGet("top-countries", Name = "top-countries")]
        public IActionResult topCountries()
        {
            var startTime = DateTime.Now;
            try
            {
                var users = _jsonUsersService.GetJson();
                List<Pais> countries = [.. users.GroupBy(u => u.pais)
                                        .Select(g => new Pais { country = g.Key, total = g.Count() })
                                        .OrderByDescending(g => g.total)
                                        .Take(5)];
                var paises = new TopCountriesResponse()
                {
                    timestamp = startTime,
                    execution_time_ms = (int)(DateTime.Now - startTime).TotalMilliseconds,
                    countries = countries
                };

                return Ok(paises);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving top countries: {ex.Message}");
            }
        }

        [HttpGet("team-insights", Name = "team-insights")]
        public IActionResult teamInsights()
        {
            var startTime = DateTime.Now;
            try
            {
                var users = _jsonUsersService.GetJson();

                //retorna total de membros, líderes, projetos concluídos e % de membros ativos.
                List<TeamInsights> teams = users.GroupBy(u => u.equipe.nome)
                    .Select(g => new TeamInsights
                    {
                        team = g.Key,
                        total_members = g.Count(),
                        leaders = g.Count(u => u.equipe.lider == true),
                        completed_projects = g.SelectMany(u => u.equipe.projetos).Count(p => p.concluido),
                        active_percentage = Math.Round((double)g.Count(u => u.ativo == true) / g.Count() * 100, 2),
                    })
                    .ToList();
                var teamInsights = new TeamInsightsResponse()
                {
                    timestamp = startTime,
                    execution_time_ms = (int)(DateTime.Now - startTime).TotalMilliseconds,
                    teams = teams
                };
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving team insights: {ex.Message}");
            }
        }

        [HttpGet("active-users-per-day", Name = "active-users-per-day")]
        public IActionResult activeUsersPerDay()
        {
            var startTime = DateTime.Now;
            try
            {
                var users = _jsonUsersService.GetJson();
                var activeUsers = users.SelectMany(u => u.logs)
                    .GroupBy(l => l.data)
                    .Select(g => new ActiveUsersPerDay
                    {
                        date = g.Key,
                        total = g.Count(l => l.acao == "login")
                    })
                    .ToList();
                var activeUsersResponse = new ActiveUsersPerDayResponse()
                {
                    timestamp = startTime,
                    execution_time_ms = (int)(DateTime.Now - startTime).TotalMilliseconds,
                    data = activeUsers
                };
                return Ok(activeUsersResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving active users per day: {ex.Message}");
            }
        }

    }
}
