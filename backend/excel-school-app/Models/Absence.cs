using System;

namespace excel_school_app.Models
{
    public class Absence
    {
         public int Id { get; set; }
         public int StudentId { get; set; }
         public DateOnly Date { get; set; }
         public DateTime StartTime { get; set; }
         public DateTime EndTime { get; set; }
         public string Reason { get; set; } = string.Empty;
         public Enums.AbsenceStatus Status { get; set; } 
         public bool IsFullDay { get; set; }
         public DateTime CreatedAt { get; set; }
           
         // Navigation property indique les relations entre models
          public Student? Student { get; set; }
    }
}
