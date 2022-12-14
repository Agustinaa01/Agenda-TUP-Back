using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;

namespace Agenda_Tup_Back.Profiles
{
    public class GroupProfile: Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupForCreation>();
            CreateMap<GroupForCreation, Group>();
        }
    }
}
