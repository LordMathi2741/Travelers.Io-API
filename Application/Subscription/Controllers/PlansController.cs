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
[ProducesResponseType(404)]
[ProducesResponseType(500)]
[AllowAnonymous]
public class PlansController(IRepositoryGeneric<Plan> repositoryGeneric, IMapper mapper) : ControllerBase
{
    private readonly IRepositoryGeneric<Plan> _repositoryGeneric = repositoryGeneric;
    private readonly IMapper _mapper = mapper;
    
    // Post: api/v1/Plans
    /// <summary>
    /// Add a new plan
    /// </summary>
    
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult>AddPlan([FromBody] PlanRequest request)
    {
        var plan = _mapper.Map<PlanRequest, Plan>(request);
        await _repositoryGeneric.AddAsync(plan);
        var planResponse = _mapper.Map<Plan, PlanResponse>(plan);
        return Ok(planResponse);
    }
}