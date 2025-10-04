using System;

namespace DigitalLogbookAPI.Models
{
    public class DailyLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Text { get; set; } = string.Empty;
        public Guid UserId { get; set; } // foreign key
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    }
}
