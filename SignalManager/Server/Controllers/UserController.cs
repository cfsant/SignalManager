using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Base.Middleware;
using System.Linq;
using System.Threading.Tasks;

namespace SignalManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpPost("[action]")]
        public async Task<UserDomain> LoginAsync([FromBody] MiddlewareDomain<UserDomain> middleware)
        {
            if (middleware == null ||
                string.IsNullOrEmpty(middleware.Objs.First().Email) || string.IsNullOrWhiteSpace(middleware.Objs.First().Email) ||
                string.IsNullOrEmpty(middleware.Objs.First().Password) || string.IsNullOrWhiteSpace(middleware.Objs.First().Password)) return null;

            UserDomain user = new UserDomain()
            {
                Email = middleware.Objs.First().Email,
                Password = middleware.Objs.First().Password
            };

            var result = await "https://localhost:8080/user/login_async".PostJsonAsync(user);

            return user;
        }
    }
}