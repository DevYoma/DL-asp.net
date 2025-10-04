using System;

namespace DigitalLogbookAPI.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // unique ID
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string SchoolName { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
