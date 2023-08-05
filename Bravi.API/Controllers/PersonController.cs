using Bravi.API.Controllers.Base;
using Bravi.Domain.Commands.Person;
using Bravi.Domain.Resources.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.API.Controllers;

[ApiController]
[Route("person")]
public class PersonController : ControllerBaseApi
{
    public PersonController(IMediator mediatR, IDomainNotificationContext notification) : base(mediatR, notification){ }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreatePersonCommand command) => await TrySendCommand(command);

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAsync([FromRoute] int id,[FromBody] UpdatePersonCommand command) => await TrySendCommand(command.SetId(id));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id) => await TrySendCommand(new DeletePersonCommand(id));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id) => await TrySendCommand(new QueryByIdPersonCommand(id));

    [HttpGet]
    public async Task<IActionResult> GetAsync() => await TrySendCommand(new QueryPersonCommand());
}