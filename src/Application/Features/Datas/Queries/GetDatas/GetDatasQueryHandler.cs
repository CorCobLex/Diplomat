using Application.Dto;
using Application.Wrappers;
using Domain.Common.Repositories;
using MapsterMapper;

namespace Application.Features.Datas.Queries.GetDatas;

public class GetDatasQueryHandler: IRequestHandler<GetDatasQuery, DatasDto>
{
    private readonly IDatasRepository _datasRepository;
    private readonly IMapper _mapper;

    public GetDatasQueryHandler(IDatasRepository datasRepository, IMapper mapper)
    {
        _datasRepository = datasRepository ?? throw new ArgumentNullException(nameof(datasRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Response<DatasDto>> Handle(GetDatasQuery request, CancellationToken cancellationToken)
    {
        var datas = await _datasRepository.GetAsync(request.Id, cancellationToken);
        var DatasDto = _mapper.Map<DatasDto>(datas);
        
        return Response.Success(DatasDto);
    }
}