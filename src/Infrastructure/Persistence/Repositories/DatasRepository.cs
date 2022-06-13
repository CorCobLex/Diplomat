using Domain.Common.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class DatasRepository : Repository<Datas>, IDatasRepository
{
    public DatasRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyCollection<Datas>> GetByGenreAsync(string data)
    {
        return await DbSet.Where(x => x.Data == data).ToListAsync();
    }
}