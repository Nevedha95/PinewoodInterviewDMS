namespace PinewoodDmsMVC.Models
{
    public class Dealer
    {
        public int Id { get; set; }           // Unique identifier for the dealer
        public string Name { get; set; }      // Name of the dealer
        public string Location { get; set; }  // Location of the dealer
        public string ContactNumber { get; set; } // Dealer's contact number
        public string Email { get; set; }
       // public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
