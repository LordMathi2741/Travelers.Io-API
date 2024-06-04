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
[ProducesResponseType(500)]
[ProducesResponseType(400)]
[AllowAnonymous]
public class PlansController(IRepositoryGeneric<Plan> repositoryGeneric, IMapper mapper) : ControllerBase
{
    private readonly IRepositoryGeneric<Plan> _repositoryGeneric = repositoryGeneric;
    private readonly IMapper _mapper = mapper;
    
    // Post: api/v1/Plans
    /// <summary>
    /// Add a new plan
    /// </summary>
    /// <param name="PlanRequest"> The plan to create </param>
    /// <response code="201"> Returns the newly created plan </response>
    /// <response code="500"> Server was down and plan post failed </response>
    /// <response code="400"> Bad request </response>
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