using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tiba.Core.Abstraction
{
    public interface ISearchService<TResult, in TSpec>
    {
        Task<TResult> SearchAsync(TSpec spec);
    }
}
