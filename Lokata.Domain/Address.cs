using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Address : EntityBase
{
    public string FullName { get; set; }

    public string Street { get; set; }

    public string Number { get; set; }

    public string PostalCode { get; set; }

    public string PostalPlace { get; set; }

    [JsonIgnore]
    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
