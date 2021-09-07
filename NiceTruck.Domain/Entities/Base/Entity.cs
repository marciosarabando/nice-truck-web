using System;

namespace NiceTruck.Domain.Entities.Base
{
    public class Entity
    {
        public int Id { get; private set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public DateTime? DateTimeUpdated { get; set; }
        public bool Active { get; private set; } = true;

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetEnabled()
        {
            Active = true;
        }

        public void SetDisabled()
        {
            Active = false;
        }

        public void SetDateTimeUpdated()
        {
            DateTimeUpdated = DateTime.Now;
        }
    }
}