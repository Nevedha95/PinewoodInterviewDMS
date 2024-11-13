using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinewoodDmsMVC.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        
        public string VIN { get; set; } 

       
        public string Make { get; set; }

       
        public string Model { get; set; }

        
        public int Year { get; set; }

       
        public string Color { get; set; }

        
        public int Mileage { get; set; }

        
        public decimal Price { get; set; }

        
        public string Transmission { get; set; } 

        
        public string FuelType { get; set; } 

        
        public string Description { get; set; }
        [ForeignKey("Dealer")]
        public  int Id { get;set;}

    }
}
