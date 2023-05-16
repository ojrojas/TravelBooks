using Core.Interfaces;

namespace Core.Entities
{
    public class RolesByUsers : BaseEntity,IAggregateRoot
    {
        public Role Role { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}