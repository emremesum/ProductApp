using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.DataAccess.User;
using ProductApp.DataAccess.Users;

namespace ProductApp.DataAccess.User
{
	public class UserConfiguration : IEntityTypeConfiguration<UserApp>
	{
		public void Configure(EntityTypeBuilder<UserApp> builder)
		{
			// Primary Key
			builder.HasKey(x => x.Id);

			// Properties
			builder.Property(x => x.Username).IsRequired();
			builder.Property(x => x.Password).IsRequired();
			builder.Property(x => x.Role).IsRequired().HasDefaultValue("Customer");
			builder.Property(x => x.IsDeleted).HasDefaultValue(false);

			// Optional: Token ve tarih alanları için default değer
			builder.Property(x => x.Token).IsRequired(false);
			builder.Property(x => x.TokenCreatedDate).IsRequired(false);
			builder.Property(x => x.UpdatedDate).HasDefaultValueSql("GETDATE()");

			// Unique constraint
			builder.HasIndex(x => x.Username).IsUnique();
		}
	}
}
