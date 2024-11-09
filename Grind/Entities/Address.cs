namespace Grind.Entities
{
    public abstract class Address
    {
        protected internal string city {  get; set; }
        protected internal string street{  get; set; }
        protected internal string apartmentNumber{  get; set; }
        public override string ToString()
        {
            return $"{street}, {apartmentNumber}, {city}";
        }
    }
}
