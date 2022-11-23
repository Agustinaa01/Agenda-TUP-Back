using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;

namespace Agenda_Tup_Back.Profiles
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactForCreation>();
            CreateMap<ContactForCreation, Contact>();
        }
    }
}
