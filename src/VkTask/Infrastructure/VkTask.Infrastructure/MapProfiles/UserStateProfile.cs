using AutoMapper;
using VkTask.Contracts.UserStates;
using VkTask.Domain.UserStates;

namespace VkTask.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для UserState.
    /// </summary>
    public class UserStateProfile : Profile
    {
        public UserStateProfile()
        {
            CreateMap<CreateUserStateDto, UserState>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.UsersList, map => map.Ignore());

            CreateMap<UserState, InfoUserStateDto>();

            CreateMap<UpdateUserStateDto, UserState>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.UsersList, map => map.Ignore());
        }
    }
}
