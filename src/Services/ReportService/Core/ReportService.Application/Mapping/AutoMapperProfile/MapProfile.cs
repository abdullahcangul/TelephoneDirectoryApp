using AutoMapper;
using PersonService.Application.DTOs.ReportDtos;
using ReportService.Domain.Entities;

namespace ReportService.Application.Mapping.AutoMapperProfile;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<ReportDto, Report>().ReverseMap();
        
        CreateMap<ReportsWithDetailsDto, Report>().ReverseMap();
        CreateMap<ReportDetailsDto, ReportDetail>().ReverseMap();

    }
}