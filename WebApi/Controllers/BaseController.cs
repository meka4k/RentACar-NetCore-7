using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BaseController:ControllerBase
{
    private IMediator? _mediator;

    protected IMediator? Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();

    //eğer bir null mediator yoksa onu döndür eğer null ise git ioc ortamına bak IMediatorun karşılığını döndür
}
