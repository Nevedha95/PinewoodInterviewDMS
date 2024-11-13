namespace PinewoodDmsMVC.Models
{
    public class Dealer
    {
        public int Id { get; set; }          
        public string Name { get; set; }      
        public string Location { get; set; }  
        public string ContactNumber { get; set; } 
        public string Email { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        // public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
