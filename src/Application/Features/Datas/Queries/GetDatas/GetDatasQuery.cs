using Application.Dto;
using Application.Wrappers;

namespace Application.Features.Datas.Queries.GetDatas;

public class GetDatasQuery : IRequest<DatasDto>
{
    public GetDatasQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}