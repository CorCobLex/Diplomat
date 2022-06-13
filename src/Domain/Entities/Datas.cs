using Domain.Common;

namespace Domain.Entities;

public class Datas : IEntity
{
    public int Id { get; set; }
    
    public DateTimeOffset? Time { get; set; }
    
    public string? Data { get; set; }
}