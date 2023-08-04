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
}