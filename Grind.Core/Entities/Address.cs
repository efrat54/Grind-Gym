namespace Grind.Core.Entities
{
    public class Address
    {
        public  string city {  get; set; }
        public string street{  get; set; }
        public string apartmentNumber{  get; set; }
        public Address(string city, string street, string apartmentNumber) {
            this.city = city;
            this.street = street;
            this.apartmentNumber = apartmentNumber;
        }
        public override string ToString()
        {
            return $"{street}, {apartmentNumber}, {city}";
        }
    }
}
