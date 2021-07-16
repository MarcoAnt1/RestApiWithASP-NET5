using RestWithASP_NET5.Hypermedia;
using RestWithASP_NET5.Hypermedia.Abstract;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestWithASP_NET5.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        [JsonPropertyName("Nome")]
        public string FirstName { get; set; }

        [JsonPropertyName("Sobrenome")]
        public string LastName { get; set; }

        [JsonPropertyName("Endereco")]
        public string Address { get; set; }

        [JsonIgnore()]
        public string Gender { get; set; }

        public bool Enabled { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
