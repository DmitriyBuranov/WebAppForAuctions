using AutoMapper;
using Otus.PublicSale.Users.Core.Domain;

namespace Otus.PublicSale.Users.WebApi.Models
{
    /// <summary>
    /// Auto Mapper Profile
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<AuthenticateModel, User>();
        }
    }
}
