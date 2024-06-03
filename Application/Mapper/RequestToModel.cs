using Application.Subscription.Request;
using AutoMapper;
using Infrastructure.subscription.Model;

namespace Application.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<PlanRequest, Plan>();
    }
}