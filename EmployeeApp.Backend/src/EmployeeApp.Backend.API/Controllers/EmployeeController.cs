using AutoMapper;
using EmployeeApp.Backend.API.Infrastructure.Models;
using EmployeeApp.Backend.AppCore.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Backend.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public EmployeeController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedEmployeeListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] EmployeeGetAllRequestModel model)
    {
        var query = new EmployeeGetAllQuery(model.PageNumber, model.PageSize);

        var result = await mediator.Send(query);

        var response = mapper.Map<PaginatedEmployeeListResponse>(result);

        return Ok(response);
    }
}
