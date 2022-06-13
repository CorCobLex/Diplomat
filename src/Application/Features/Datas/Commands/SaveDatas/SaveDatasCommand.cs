using Application.Wrappers;

namespace Application.Features.Datas.Commands.SaveDatas;

public class SaveDatasCommand : IRequest<int>
{
    public DateTimeOffset? Time { get; set; }
    
    public string? Data { get; set; }
}