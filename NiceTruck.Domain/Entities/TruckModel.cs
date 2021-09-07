using System;
using System.Collections.Generic;
using System.Linq;
using NiceTruck.Domain.Entities.Base;

namespace NiceTruck.Domain.Entities
{
    public class TruckModel : Entity
    {
        public TruckModel(int id, string description)
        {
            base.SetId(id);
            Description = description;
            base.SetEnabled();
        }

        public string Description { get; private set; }


        public ICollection<Truck> Trucks { get; private set; }

        public bool IsValid()
        {
            var descriptions = new[] { "FH", "FM" };
            return Description.Contains(descriptions.ToString());
        }
    }
}