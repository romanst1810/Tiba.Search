using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tiba.BussinessLayer.Services.Bookmark;
using Tiba.Core.Domain;

namespace Tiba.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : Controller
    {
        private IBookmarkService _bookmarkService;
        private string UserId => this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            this._bookmarkService = bookmarkService;

        }

        // GET: api/Bookmark
        [HttpGet]
        public async Task<SearchResult> Get()
        {
            var model = await _bookmarkService.FetchAsync(this.UserId);

            return model;
        }

        // POST: api/Bookmark
        [HttpPost]
        public async Task Post([FromBody] RepositoryItem model)
        {
            model.UserId = this.UserId ?? "Anonimus";
            await this._bookmarkService.SaveAsync(model);
        }
    }
}