namespace CarRegistrationLibrary.Domain
{
    public struct Car
    {

        internal static Car FromDbLine(string dbString)
        {
            var split = dbString.Trim().Split(',');
            return new Car(split[0], split[1]);
        }

        public Car(string vin, string name)
        {
            Vin = vin;
            Name = name;
        }

        public string Vin { get; set; }
        public string Name { get; set;  }

        public string ToDbLine()
        {
            return $"{Vin},{Name}";
        }
    }
}