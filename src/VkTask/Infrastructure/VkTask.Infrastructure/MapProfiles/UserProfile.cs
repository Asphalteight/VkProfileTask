using AutoMapper;
using VkTask.Contracts.Users;
using VkTask.Domain.Users;

namespace VkTask.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для User.
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(s => s.CreatedDate, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.UserGroup, map => map.Ignore())
                .ForMember(s => s.UserState, map => map.Ignore())
                .ForMember(s => s.UserStateId, map => map.MapFrom(s => 1));

            CreateMap<User, InfoUserDto>();

            CreateMap<UpdateUserDto, User>()
                .ForMember(s => s.CreatedDate, map => map.Ignore())
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.UserGroup, map => map.Ignore())
                .ForMember(s => s.UserState, map => map.Ignore());
        }
    }
}
