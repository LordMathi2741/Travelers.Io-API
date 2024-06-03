using Application.Subscription.Response;
using AutoMapper;
using Infrastructure.subscription.Model;

namespace Application.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Plan, PlanResponse>();
    }
}