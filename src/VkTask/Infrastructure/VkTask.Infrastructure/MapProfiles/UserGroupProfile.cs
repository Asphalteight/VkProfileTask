using AutoMapper;
using VkTask.Contracts.UserGroups;
using VkTask.Domain.UserGroups;

namespace VkTask.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для UserGroup.
    /// </summary>
    public class UserGroupProfile : Profile
    {
        public UserGroupProfile()
        {
            CreateMap<CreateUserGroupDto, UserGroup>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.UsersList, map => map.Ignore());

            CreateMap<UserGroup, InfoUserGroupDto>();

            CreateMap<UpdateUserGroupDto, UserGroup>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.UsersList, map => map.Ignore());
        }
    }
}
