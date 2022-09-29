namespace Assignment1
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }

        public void ValidateName()
        {
            if(Name == null) throw new ArgumentNullException(nameof(Name));
            if (Name.Length < 2) throw new ArgumentException("Give at least 2 characters");
        }
        public void ValidateAge()
        {
            if (Age < 2) throw new ArgumentOutOfRangeException(nameof(Age));
        }
        public void ValidateShirtNumber()
        {           
            if (ShirtNumber < 1 || ShirtNumber > 99) throw new ArgumentOutOfRangeException(nameof(ShirtNumber));
        }
        public string ToString()
        {
            return Id + " " + Name + " " + Age + " " + ShirtNumber;
        }
    }
}