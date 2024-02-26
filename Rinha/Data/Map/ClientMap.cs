using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rinha;

public class ClientMap : IEntityTypeConfiguration<ClientModel>
{
    public void Configure(EntityTypeBuilder<ClientModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Limit).IsRequired();
        builder.Property(x => x.Balance).IsRequired();
    }
}
