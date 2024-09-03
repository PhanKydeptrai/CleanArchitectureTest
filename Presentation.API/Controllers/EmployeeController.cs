using Application.Feature.CreateNewEmployee;
using Application.Feature.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ISender _sender;
    public EmployeeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult?> Employee(int id)
    {
        var employee = await _sender.Send(new GetEmployeeByIdQuery(id));
        if(employee == null)
        {
            return NotFound("Không tìm thấy nhân viên!");
       }
        return Ok(employee);
    }


    [HttpPost]
    public async Task<IActionResult> Employee(CreateEmployeeCommand command)
    {
        
        var status = await _sender.Send(command);
        
        if(status.Data != true)
        {
            return BadRequest(status.Errors);
        }
        return Ok("Thêm thành công!");
    }

}

