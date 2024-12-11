namespace Grind.Core.Entities
{
    public class Address
    {
        public int id { get; set; }
        public string city {  get; set; }
        public string street{  get; set; }
        public string apartmentNumber{  get; set; }
        public Address(int id,string city, string street, string apartmentNumber) {
            this.id = id;
            this.city = city;
            this.street = street;
            this.apartmentNumber = apartmentNumber;
        }
        public Address() { }
        public override string ToString()
        {
            return $"{street}, {apartmentNumber}, {city}";
        }
    }
}
