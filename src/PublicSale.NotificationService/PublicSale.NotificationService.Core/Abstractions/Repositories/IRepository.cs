using PublicSale.NotificationService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Abstractions.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    { }
}
