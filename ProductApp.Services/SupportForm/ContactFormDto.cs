namespace ProductApp.Services.SupportForm
{
	public class ContactFormDto
	{
		public ContactFormDto(int id, int userId, string subject, string message, string status , DateTime updatedDate, DateTime createdDate, bool isDeleted)
		{
			Id= id;
			UserId= userId;
			Subject= subject;
			Message= message;
			Status= status;
			UpdatedDate= updatedDate;
			CreatedDate= createdDate;
		    IsDeleted= isDeleted;
		}

		public int Id { get; set; }
		public int UserId { get; set; }
		public string Subject { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
		public DateTime UpdatedDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsDeleted { get; set; } = false;
	}
}
