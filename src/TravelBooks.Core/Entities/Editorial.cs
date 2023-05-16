using Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    /// <summary>
    /// Model Editoral 
    /// </summary>
    public class Editorial : BaseEntity, IAggregateRoot
    {
        [StringLength(45)]
        public string Name { get; set; }
        [StringLength(45)]
        public string Sede { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
