using Domain.Entities;

namespace Domain.Common.Repositories;

public interface IDatasRepository : IRepository<Datas>
{
    Task<IReadOnlyCollection<Datas>> GetByGenreAsync(string data);
}