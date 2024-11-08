using Microsoft.AspNetCore.Http;


namespace ProductApp.Services.SupportForm;

public interface IContactFormService
{
    Task<ServiceResult<List<ContactFormDto>>> GetAllListAsync();
    Task<ServiceResult<CreateContactFormResponse>> CreateAsync(CreateContactFormRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateContactFormRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}
