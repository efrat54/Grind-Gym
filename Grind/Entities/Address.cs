namespace Grind.Entities
{
    public class Address
    {
        protected internal string city {  get; set; }
        protected internal string street{  get; set; }
        protected internal string apartmentNumber{  get; set; }
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
