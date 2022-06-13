using Application.Dto;
using Application.Wrappers;
using Domain.Common.Repositories;
using MapsterMapper;

namespace Application.Features.Datas.Queries.GetDatass;

public class GetAllDatasQueryHandler : IRequestHandler<GetAllDatassQuery, IEnumerable<DatasDto>>
{
    private readonly IDatasRepository _datasRepository;
    private readonly IMapper _mapper;

    public GetAllDatasQueryHandler(IDatasRepository datasRepository, IMapper mapper)
    {
        _datasRepository = datasRepository ?? throw new ArgumentNullException(nameof(datasRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Response<IEnumerable<DatasDto>>> Handle(GetAllDatassQuery request, CancellationToken cancellationToken)
    {
        var datas = await _datasRepository.GetAllAsync(cancellationToken);
        var dataDto = _mapper.Map<IEnumerable<DatasDto>>(datas);

        return Response.Success(dataDto);
    }
}