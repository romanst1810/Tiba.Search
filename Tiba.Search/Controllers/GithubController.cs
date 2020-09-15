using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tiba.BussinessLayer.Services.Github;
using Tiba.Core.Domain;

namespace Tiba.Search.Controllers
{
    [Route("api/[controller]")]
    public class GithubController : Controller
    {
        private IGithubService githubService;

        public GithubController(IGithubService service)
        {
            this.githubService = service;
        }

        // GET: api/Bookmark
        [HttpGet("search/{text}")]
        public async Task<SearchResult> Get(string text)
        {
            var spec = new RepositorySearchSpecification()
            {
                Text = text
            };

            return await this.githubService.SearchAsync(spec);
        }
    }
}