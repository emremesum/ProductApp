using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductApp.DataAccess.SupportForm;

public class ContactFormConfiguration : IEntityTypeConfiguration<ContactForm>
{
    public void Configure(EntityTypeBuilder<ContactForm> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).IsRequired();
    }
}
