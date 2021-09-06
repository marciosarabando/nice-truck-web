using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NiceTruck.Application.ViewModels
{
    public class TruckViewModelDetails
    {
        public int Id { get; set; }
        public int IdTruckModel { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Fabrication Year")]
        public int FabricationYear { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Model Year")]
        public int ModelYear { get; set; }

        [DisplayName("DateTime Created")]
        public DateTime DateTimeCreated { get; set; }

        [DisplayName("DateTime Updated")]
        public DateTime? DateTimeUpdated { get; set; }


        [NotMapped]
        [DisplayName("Truck Model")]
        public TruckModelViewModel TruckModel { get; set; }
    }
}