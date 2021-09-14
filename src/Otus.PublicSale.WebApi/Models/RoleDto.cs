using Otus.PublicSale.Core.Domain;
using Otus.PublicSale.Core.Domain.Administration;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// Role Dto
    /// </summary>
    public class RoleDto: BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        public RoleDto()
        {
            
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="role">Role</param>
        public RoleDto(Role role)
        {
            Id = role.Id;
            Name = role.Name;
        }
    }
}
