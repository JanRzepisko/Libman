using Shared.Definitions;

namespace Library.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string country)
    {
        Street = street;
        City = city;
        Country = country;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return Country;
    }
}
