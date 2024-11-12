using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinewoodDmsMVC.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        
        public string VIN { get; set; }  // Vehicle Identification Number

       
        public string Make { get; set; }

       
        public string Model { get; set; }

        
        public int Year { get; set; }

       
        public string Color { get; set; }

        
        public int Mileage { get; set; }

        
        public decimal Price { get; set; }

        
        public string Transmission { get; set; } // e.g., Automatic, Manual

        
        public string FuelType { get; set; } // e.g., Gasoline, Diesel, Electric

        
        public string Description { get; set; }
        [ForeignKey("Dealer")]
        public  int Id { get;set;}
    }
}
