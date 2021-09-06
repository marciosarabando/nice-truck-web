using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NiceTruck.Application.ViewModels
{
    public class TruckModelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Model")]
        public string Description { get; set; }

        [NotMapped]
        public IEnumerable<TruckViewModel> Trucks { get; set; }
    }
}