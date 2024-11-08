using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess;
using ProductApp.DataAccess.SupportForm;
using System.Net;

namespace ProductApp.Services.SupportForm;

public class ContactFormService(IContactFormRepository contactFormRepository, IUnitOfWork unitOfWork) : IContactFormService
{
	public async Task<ServiceResult<List<ContactFormDto>>> GetAllListAsync()
	{

		var contactForms = await contactFormRepository.GetAll().ToListAsync();
		var contactFormDto = contactForms.Select(x => new ContactFormDto(x.Id, x.UserId, x.Subject, x.Message, x.Status, x.UpdatedDate, x.CreatedDate, x.IsDeleted)).ToList();
		return ServiceResult<List<ContactFormDto>>.Success(contactFormDto);
	}

	
	public async Task<ServiceResult> DeleteAsync(int id)
	{
		var contactForm = await contactFormRepository.GetByIdAsync(id);
		if (contactForm == null)
		{
			return ServiceResult.Fail("contactForm not found", HttpStatusCode.NotFound);
		}

		if (contactForm.IsDeleted == true)
		{
			return ServiceResult.Fail("contactForm is already deleted", HttpStatusCode.BadRequest);
		}

		contactForm.IsDeleted = true;
		contactForm.UpdatedDate = DateTime.Now;
		contactForm.Status = "Silinmiş";

		contactFormRepository.Update(contactForm);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult.Success();
	}
	public async Task<ServiceResult> UpdateAsync(int id, UpdateContactFormRequest request)
	{
		var contactForm = await contactFormRepository.GetByIdAsync(id);

		if (contactForm == null || contactForm.IsDeleted == true)
		{
			return ServiceResult.Fail("contactForm not found", HttpStatusCode.NotFound);
		}
		contactForm.Subject = request.contactFormDto.Subject;
		contactForm.Message = request.contactFormDto.Message;
		contactForm.Status = "İşlem yapılmış" ;
		contactForm.UpdatedDate= DateTime.Now;


		contactFormRepository.Update(contactForm);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult.Success();
	}
	public async Task<ServiceResult<CreateContactFormResponse>> CreateAsync(CreateContactFormRequest request)
	{

		var contactForm = new ContactForm()
		{
			UserId = request.contactFormDto.UserId,
			Subject = request.contactFormDto.Subject,
			Message = request.contactFormDto.Message,
			Status = "İşlem Yapılmamış",
			CreatedDate = DateTime.Now
			

		};

		await contactFormRepository.AddAsync(contactForm);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult<CreateContactFormResponse>.Success(new CreateContactFormResponse(contactForm.Id));
	}
}

