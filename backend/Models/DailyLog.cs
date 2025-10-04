using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using System;

namespace DigitalLogbookAPI.Models
{
    [Table("dailyLogs")]
    public class DailyLog : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("text")]
        public string Text { get; set; } = string.Empty;

        [Column("date")]
        public DateTime Date { get; set; }
    }
}
