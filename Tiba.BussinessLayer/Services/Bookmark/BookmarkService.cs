using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiba.Core.Domain;
using Tiba.DataLayer;

namespace Tiba.BussinessLayer.Services.Bookmark
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _repository;

        public BookmarkService(IBookmarkRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task SaveAsync(RepositoryItem context)
        {
            var items = await _repository.FindAsync(context.UserId);
            var item = items.SingleOrDefault(x => x.FullName == context.FullName);
            if (item == null)
            {
                item = new RepositoryItem()
                {
                    FullName = context.FullName,
                    Url = context.Url,
                    UserId = context.UserId
                };
                await _repository.CreateAsync(item);
            }
            await Task.CompletedTask;
        }

        public async Task<SearchResult> FetchAsync(string userId)
        {
            var items = await _repository.FindAsync(userId);
            var result = new SearchResult
            {
                Items = items.ToArray(),
                Total = items.Count()
            };
            return result;
        }
    }
}
