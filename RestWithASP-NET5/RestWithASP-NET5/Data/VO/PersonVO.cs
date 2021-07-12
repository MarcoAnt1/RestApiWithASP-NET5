using System.Text.Json.Serialization;

namespace RestWithASP_NET5.Data.VO
{
    public class PersonVO
    {
        public int Id { get; set; }

        [JsonPropertyName("Nome")]
        public string FirstName { get; set; }

        [JsonPropertyName("Sobrenome")]
        public string LastName { get; set; }

        [JsonPropertyName("Endereco")]
        public string Address { get; set; }

        [JsonIgnore()]
        public string Gender { get; set; }
    }
}
