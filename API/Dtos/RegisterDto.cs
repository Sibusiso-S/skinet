using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public class RegisterDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Displayname { get; set; }

		[Required]
		[RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "1 Uppercase, 1 Lowercase, 1 number, 1 non-alphanumeric and more than 6 characters")]
		public string Password { get; set; }

	}
}