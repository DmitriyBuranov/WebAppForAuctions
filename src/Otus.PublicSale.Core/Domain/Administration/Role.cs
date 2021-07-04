using System.Collections.Generic;

namespace Otus.PublicSale.Core.Domain.Administration
{
    /// <summary>
    /// Roles
    /// </summary>
    public partial class Role: BaseEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Role()
        {
            Users = new HashSet<User>();
        }
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
