using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinhaBackend2023Q3.Domain.Entities.Common;

namespace RinhaBackend2023Q3.Infra.Data.Configurations;

public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name);
        builder.Property(e => e.Nickname);
        builder.Property(e => e.BirthDate);

        builder
            .Property(e => e.Stack)
            .HasConversion(
                v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
                v => JsonSerializer.Deserialize<ICollection<string>>(v, null as JsonSerializerOptions)
            );
    }
}
