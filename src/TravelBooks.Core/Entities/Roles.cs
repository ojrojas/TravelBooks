using System;
using Core.Interfaces;

namespace Core.Entities
{
    public class Role : BaseEntity,IAggregateRoot
    {
        public string Description { get; set; }
    }
}