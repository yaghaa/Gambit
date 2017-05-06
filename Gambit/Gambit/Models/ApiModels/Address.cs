namespace Gambit.Models.ApiModels
{
    public class Address
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public int HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public int AddressId { get; set; }
    }
}