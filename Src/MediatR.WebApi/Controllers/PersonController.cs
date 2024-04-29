using DemoMediatR.Application.Commands;

using MediatR;
using MediatR.Application.Commands;
using MediatR.Application.Queries;

using Microsoft.AspNetCore.Mvc;

namespace DemoMediatR.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPersons()
    {
        var query = new GetPersonsQuery();
        var members = await mediator.Send(query);
        return Ok(members);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(int id)
    {
        var query = new GetPersonByIdQuery { Id = id };
        var member = await mediator.Send(query);

        return member != null ? Ok(member) : NotFound("Member not found.");
    }

    /// <summary>
    /// Criar um nova Pessoa
    /// </summary>
    /// <param name="command">Objeto para criar uma nova pessoa</param>
    /// <returns>Retorna objeto Person criado</returns>
    [ProducesResponseType(typeof(CreatePersonCommand), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
    {
        var createdMember = await mediator.Send(createPersonCommand);
        return CreatedAtAction(nameof(GetPerson), new { id = createdMember.Id }, createdMember);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(int id, UpdatePersonCommand command)
    {
        command.Id = id;
        var updatedMember = await mediator.Send(command);

        return updatedMember != null ? Ok(updatedMember) : NotFound("Member not found.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var command = new DeletePersonCommand { Id = id };
        await mediator.Send(command);

        return Ok();
    }
}
