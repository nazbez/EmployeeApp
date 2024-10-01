using AutoMapper;
using EmployeeApp.Backend.API.Infrastructure.Models.Department;
using EmployeeApp.Backend.AppCore.Department.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Backend.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public DepartmentController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<DepartmentVm>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var query = new DepartmentGetAllQuery();

        var result = await mediator.Send(query);

        var response = result.Select(mapper.Map<DepartmentVm>).ToList();

        return Ok(response);
    }
}
