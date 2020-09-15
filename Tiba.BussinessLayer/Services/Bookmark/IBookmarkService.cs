using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiba.Core.Domain;

namespace Tiba.BussinessLayer.Services.Bookmark
{
    public interface IBookmarkService
    {
        Task SaveAsync(RepositoryItem item);

        Task<SearchResult> FetchAsync(string userId);
    }

    //public class BookmarkContext
    //{
    //    public string UserId { get; set; }

    //    public RepositoryItem Item { get; set; }
    //}
}
