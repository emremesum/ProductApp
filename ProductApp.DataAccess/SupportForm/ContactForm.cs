

namespace ProductApp.DataAccess.SupportForm;

public class ContactForm
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public string Subject { get; set; } = string.Empty;
	public string Message { get; set; } = string.Empty;
	public string Status { get; set; } = string.Empty;
	public DateTime UpdatedDate { get; set; }
	public DateTime CreatedDate { get; set; }
	public bool IsDeleted { get; set; } = false;

}
