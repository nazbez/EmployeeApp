using AutoMapper;
using EmployeeApp.Backend.API.Infrastructure.Models.Employee;
using EmployeeApp.Backend.AppCore.Employee.Commands;
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
    [ProducesResponseType(typeof(PaginatedEmployeeListResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] EmployeeGetAllRequestModel model)
    {
        var query = new EmployeeGetAllQuery(model.PageNumber, model.PageSize);

        var result = await mediator.Send(query);

        var response = mapper.Map<PaginatedEmployeeListResponseModel>(result);

        return Ok(response);
    }

    [HttpGet("upsert-data")]
    [ProducesResponseType(typeof(EmployeeUpsertDataResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUpsertData()
    {
        var query = new EmployeeGetUpsertDataQuery();
        
        var result = await mediator.Send(query);

        var response = mapper.Map<EmployeeUpsertDataResponseModel>(result);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] EmployeeUpsertRequestModel requestModel)
    {
        var command = mapper.Map<EmployeeCreateCommand>(requestModel);

        await mediator.Send(command);

        return Created();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeUpsertRequestModel requestModel)
    {
        var command = mapper.Map<EmployeeUpdateCommand>(requestModel);

        command.Id = id;

        await mediator.Send(command);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new EmployeeDeleteCommand(id);

        await mediator.Send(command);

        return Ok();
    }
}
