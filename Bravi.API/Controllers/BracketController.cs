using Bravi.API.Controllers.Base;
using Bravi.Domain.Commands.Brackets;
using Bravi.Domain.Resources.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.API.Controllers;

[ApiController]
[Route("bracket")]
public class BracketController : ControllerBaseApi
{

    public BracketController(IMediator mediatR, IDomainNotificationContext notification) : base(mediatR, notification)
    {
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] BracketsCommand command) => await TrySendCommand(command);
}