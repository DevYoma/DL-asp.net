using System;

namespace DigitalLogbookAPI.DTOs
{
	public class RegisterDto
	{
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string StudentName { get; set; } = string.Empty;
		public string Department { get; set; } = string.Empty;
		public string SchoolName { get; set; } = string.Empty;
		public string Duration { get; set; } = string.Empty;
		public DateTime StartDate { get; set; }	
	}
}
