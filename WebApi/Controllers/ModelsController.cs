using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest paginate)
    {
        GetListModelQuery getListModelQuery = new GetListModelQuery()
        {
            PageRequest = paginate
        };

        GetListResponse<GetListModelListItemDto> response = await Mediator.Send(getListModelQuery);
        return Ok(response);
    }

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest paginate, [FromBody] DynamicQuery? dynamicQuery=null)
    {
        GetListByDynamicModelQuery getListByDynamicModelQuery = new GetListByDynamicModelQuery()
        {
            PageRequest = paginate,
            DynamicQuery= dynamicQuery
        };

        GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(getListByDynamicModelQuery);
        return Ok(response);
    }
}
