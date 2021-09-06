using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NiceTruck.Application.ViewModels
{
    public class TruckViewModel
    {
        public int Id { get; set; }

        [DisplayName("Truck Model")]
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

        [NotMapped]
        [DisplayName("Truck Model")]
        public TruckModelViewModel TruckModel { get; set; }

        [NotMapped]
        [DisplayName("Truck Model")]
        public IEnumerable<TruckModelViewModel> TruckModels { get; set; }
    }
}