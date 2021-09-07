using System;
using NiceTruck.Domain.Entities.Base;
using NiceTruck.Domain.Enums;

namespace NiceTruck.Domain.Entities
{
    public class Truck : Entity
    {
        public Truck()
        {
        }

        public Truck(string description, int fabricationYear, int modelYear, ETruckModel TruckModel)
        {
            Description = description;
            FabricationYear = fabricationYear;
            ModelYear = modelYear;
            IdTruckModel = (int)TruckModel;
        }

        public string Description { get; private set; }
        public int IdTruckModel { get; private set; }
        public int FabricationYear { get; private set; }
        public int ModelYear { get; private set; }

        public TruckModel TruckModel { get; private set; }

        public bool IsValid()
        {
            var currentYear = int.Parse(DateTime.Now.ToString("yyyy"));

            if (FabricationYear != currentYear
                || ModelYear < currentYear
                || ModelYear > currentYear + 1
                || IdTruckModel > 2)
                return false;
            else
                return true;
        }
    }
}