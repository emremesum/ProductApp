using ProductApp.DataAccess.SupportForm;

namespace ProductApp.DataAccess.SupportForm;

public class ContactFormRepository(ProductAppDbContext context) : GenericRepository<ContactForm>(context), IContactFormRepository
{

}
