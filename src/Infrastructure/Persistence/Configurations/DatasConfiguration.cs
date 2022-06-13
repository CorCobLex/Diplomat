using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DatasConfiguration : IEntityTypeConfiguration<Datas>
{
    public void Configure(EntityTypeBuilder<Datas> builder)
    {
        builder.ToTable(nameof(Datas));
    }
}