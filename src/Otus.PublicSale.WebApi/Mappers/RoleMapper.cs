using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Mappers
{
    public class RoleMapper
    {
        /// <summary>
        /// Creates or updates Role from Dto request
        /// </summary>
        /// <param name="request">Role Dto</param>
        /// <param name="role">Role</param>
        /// <returns>Role</returns>
        public static Role MapFromModel(RoleDto request, Role role = null)
        {
            if (role == null)
                role = new Role();

            role.Name = request.Name;

            return role;
        }
    }
}
