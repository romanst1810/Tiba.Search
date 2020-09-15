using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tiba.Core.Domain
{
    public class SearchResult
    {
        [JsonProperty("total_count")]
        public int Total { get; set; }


        [JsonProperty("items")]
        public RepositoryItem[] Items { get; set; }
    }
}
