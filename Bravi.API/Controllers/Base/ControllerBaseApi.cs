using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Bravi.Domain.Resources.Notification;

namespace Bravi.API.Controllers.Base;

public abstract class ControllerBaseApi : ControllerBase
{
    public readonly IMediator _mediator;
    public readonly IDomainNotificationContext _domainNotificationContext;

    protected ControllerBaseApi(IMediator mediator, IDomainNotificationContext domainNotificationContext)
    {
        _mediator = mediator;
        _domainNotificationContext = domainNotificationContext;
    }

    public async Task<IActionResult> TrySendCommand<TRequest>(TRequest command, int? statusCode = null)
    {
        object value = await _mediator.Send(command, default);
        AddModelStateErrorsInNotifications();
        if (_domainNotificationContext.HasErrorNotifications)
        {
            return BadRequestDomainError();
        }

        return StatusCode(statusCode ?? 200, value);
    }

    private void AddModelStateErrorsInNotifications()
    {
        if (ModelState.IsValid)
        {
            return;
        }

        foreach (var item in (from error in ModelState.SelectMany((KeyValuePair<string, ModelStateEntry> modelState) => modelState.Value.Errors)
                              select new { error.ErrorMessage }).ToList())
        {
            _domainNotificationContext.NotifyError(item.ErrorMessage);
        }
    }

    private IActionResult BadRequestDomainError()
    {
        IEnumerable<string> errors = from x in _domainNotificationContext.GetErrorNotifications()
                                     select x.Value;
        return BadRequest(new
        {
            Success = false,
            Errors = errors
        });
    }
}
