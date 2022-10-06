using AutoMapper;
using PersonService.Application.DTOs.ContactDto;
using PersonService.Application.DTOs.PersonDto;
using PersonService.Application.Features.Commands.ContactCommands.CreateContact;
using PersonService.Application.Features.Commands.CreatePerson;
using PersonService.Domain.Entities;

namespace PersonService.Application.Mapping.AutoMapperProfile;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<CreatePersonCommandRequest, Person>().ReverseMap();
        CreateMap<PersonDto, Person>().ReverseMap();
        
        CreateMap<CreateContactCommandRequest, Contact>().ReverseMap();
        CreateMap<ContactDto, Contact>().ReverseMap();
    }
}