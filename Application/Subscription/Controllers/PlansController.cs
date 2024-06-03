using System.Net.Mime;
using Application.Subscription.Request;
using Application.Subscription.Response;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.subscription.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Subscription.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
public class PlansController(IRepositoryGeneric<Plan> repositoryGeneric, IMapper mapper) : ControllerBase
{
    private readonly IRepositoryGeneric<Plan> _repositoryGeneric = repositoryGeneric;
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task<IActionResult>AddPlan([FromBody] PlanRequest request)
    {
        var plan = _mapper.Map<PlanRequest, Plan>(request);
        await _repositoryGeneric.AddAsync(plan);
        var planResponse = _mapper.Map<Plan, PlanResponse>(plan);
        return Ok(planResponse);
    }
}