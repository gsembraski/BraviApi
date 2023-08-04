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

    [HttpGet]
    public async Task<IActionResult> GetAsync() => await TrySendCommand(new QueryPersonCommand());
}