using System;

namespace DigitalLogbookAPI.DTOs
{
    public class LogDto
    {
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    }
}
