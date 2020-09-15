using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiba.Core.Domain;
using System.Linq;

namespace Tiba.DataLayer
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly DbContext dbContext;

        public BookmarkRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<List<RepositoryItem>> FindAsync(string userId)
        {
            var bookmarks = dbContext.Set<RepositoryItem>()
                .Where(x => x.UserId == userId).ToListAsync();
            return bookmarks;
        }

        public Task<RepositoryItem> GetByIdAsync(int id)
        {
            var cart = dbContext.Set<RepositoryItem>()
                .SingleAsync(x => x.Id == id);
            return cart;
        }

        public Task CreateAsync(RepositoryItem item)
        {
            this.dbContext.Add(item);
            return this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(RepositoryItem item)
        {
            var cart = await dbContext.Set<RepositoryItem>()
                .SingleOrDefaultAsync(x => x.UserId == item.UserId && x.FullName == item.FullName);
            if (cart != null)
            {
                this.dbContext.Remove(cart);
            }
            this.dbContext.Add(item);
            await this.dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(RepositoryItem item)
        {
            this.dbContext.Remove(item);
            return this.dbContext.SaveChangesAsync();
        }
    }
}
