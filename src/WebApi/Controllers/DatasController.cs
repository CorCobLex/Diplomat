using Application.Dto;

using Application.Features.Datas.Commands.SaveDatas;
using Application.Features.Datas.Queries.GetDatas;
using Application.Features.Datas.Queries.GetDatass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatasResponse = Application.Wrappers.Response<System.Collections.Generic.IEnumerable<Application.Dto.DatasDto>>;

namespace WebApi.Controllers;

[Authorize]
public class DatasController : ApiControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<DatasDto>> GetDatas(int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetDatasQuery(id), cancellationToken));
    }
    
    [HttpGet]
    public async Task<ActionResult<DatasResponse>> GetAllDatas(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetAllDatassQuery(), cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<int>> SaveDatas([FromBody] SaveDatasCommand saveDatasCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(saveDatasCommand, cancellationToken));
    }
}