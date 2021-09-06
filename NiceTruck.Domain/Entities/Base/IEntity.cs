using System;

namespace NiceTruck.Domain.Entities.Base
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime DateTimeCreated { get; set; }
        DateTime? DateTimeUpdated { get; set; }
    }
}