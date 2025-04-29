using Desafio_Tecnico.Models;
using System.Text.Json;

namespace Desafio_Tecnico.Services
{
    public interface IJsonUsersService { 
        void StoreJson(string json);
        void StoreUsers(List<User> users);
        List<User> GetJson();
    }
    public class JsonUsersService : IJsonUsersService
    {
        private List<User> _users;
        public List<User> GetJson()
        {
            return _users;
        }

        public void StoreJson(string json)
        {
            _users = JsonSerializer.Deserialize<List<User>>(json);
        }

        public void StoreUsers(List<User> users)
        {
            _users = users;
        }
    }
}
