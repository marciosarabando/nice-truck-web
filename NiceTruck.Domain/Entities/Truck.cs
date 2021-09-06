using System;
using NiceTruck.Domain.Entities.Base;

namespace NiceTruck.Domain.Entities
{
    public class Truck : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IdTruckModel { get; set; }
        public int FabricationYear { get; set; }
        public int ModelYear { get; set; }
        public bool Active { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }

        public TruckModel TruckModel { get; set; }
    }
}