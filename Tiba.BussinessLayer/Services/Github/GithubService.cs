using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiba.Core.Domain;

namespace Tiba.BussinessLayer.Services.Github
{
    public class GithubService : IGithubService

    {
        private readonly string apiUrl = "https://api.github.com";
        private IGitHubApi apiProxy;

        public GithubService()
        {
            apiProxy = RestService.For<IGitHubApi>(apiUrl);
        }

        public async Task<SearchResult> SearchAsync(RepositorySearchSpecification spec)
        {
            spec = spec ?? throw new ArgumentNullException(nameof(spec));

            return await apiProxy.SearchAsync(spec.Text);
        }
    }
}
