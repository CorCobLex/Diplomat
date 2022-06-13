using Application.Wrappers;
using Domain.Common;
using Domain.Common.Repositories;
using Domain.Entities;
using MapsterMapper;

namespace Application.Features.Datas.Commands.SaveDatas;

public class SaveDatasCommandHandler : IRequestHandler<SaveDatasCommand, int>
{
    private readonly IDatasRepository _DatasRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SaveDatasCommandHandler(IDatasRepository datasRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _DatasRepository = datasRepository ?? throw new ArgumentNullException(nameof(datasRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Response<int>> Handle(SaveDatasCommand request, CancellationToken cancellationToken)
    {
        
        var datas = _mapper.Map<Domain.Entities.Datas>(request);
        await _DatasRepository.SaveAsync(datas, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return Response.Success(datas.Id);

    }
}