using System;
using System.Collections.Generic;
using System.Text;
using Tiba.Core.Abstraction;
using Tiba.Core.Domain;

namespace Tiba.BussinessLayer.Services.Github
{
    public interface IGithubService : ISearchService<SearchResult, RepositorySearchSpecification>
    {
    }
}
