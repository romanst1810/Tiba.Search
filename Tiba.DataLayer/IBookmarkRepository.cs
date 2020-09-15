using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiba.Core.Domain;

namespace Tiba.DataLayer
{
    public interface IBookmarkRepository
    {
        Task<List<RepositoryItem>> FindAsync(string userId);

        Task<RepositoryItem> GetByIdAsync(int userId);

        Task CreateAsync(RepositoryItem item);

        Task UpdateAsync(RepositoryItem item);

        Task DeleteAsync(RepositoryItem item);
    }
}
