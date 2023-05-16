using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    /// <summary>
    /// Model Book
    /// </summary>
    public class Book: BaseEntity, IAggregateRoot
    {
        [StringLength(45)]
        public string Titulo { get; set; }
        public string Sipnosis { get; set; }
        public int Pages { get; set; }
        public Guid EditorialId { get; set; }
        public Editorial Editorial { get; set; }
        public ICollection<AuthorsBooks> AuthorsBooks { get; set; }
    }

}
