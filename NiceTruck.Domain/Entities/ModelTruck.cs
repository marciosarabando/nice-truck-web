using System;
using System.Collections.Generic;
using NiceTruck.Domain.Entities.Base;

namespace NiceTruck.Domain.Entities
{
    public class TruckModel : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}