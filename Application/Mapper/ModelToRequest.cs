using Application.Subscription.Request;
using AutoMapper;
using Infrastructure.subscription.Model;

namespace Application.Mapper;

public class ModelToRequest : Profile
{
    
    public ModelToRequest()
    {
         CreateMap<Plan, PlanRequest>();
    }
    
}