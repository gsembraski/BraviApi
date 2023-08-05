using Bravi.API.Controllers.Base;
using Bravi.Domain.Commands.Contact;
using Bravi.Domain.Resources.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.API.Controllers;

[ApiController]
[Route("contact")]
public class ContactController : ControllerBaseApi
{

    public ContactController(IMediator mediatR, IDomainNotificationContext notification) : base(mediatR, notification) { }

    [HttpPost("{personId:int}")]
    public async Task<IActionResult> PostAsync([FromRoute] int personId,[FromBody] CreateContactCommand command) => await TrySendCommand(command.SetIds(personId));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateContactCommand command) => await TrySendCommand(command.SetId(id));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id) => await TrySendCommand(new DeleteContactCommand(id));

    [HttpGet("{personId:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int personId) => await TrySendCommand(new QueryContactCommand(personId));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id) => await TrySendCommand(new QueryByIdContactCommand(id));
}