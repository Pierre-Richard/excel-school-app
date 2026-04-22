using System;

namespace excel_school_app.Models
{
    public class Grade
    {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public int TeacherId { get; set; }
            public Enums.Subject Subject { get; set; }
            public double Value { get; set; }
            public string Appreciation { get; set; } = string.Empty;
            public DateOnly ExamDate { get; set; }
            public Enums.Term Term { get; set; }

             // Navigation property indique les relations entre models

             public Student? Student { get; set; }
             public Teacher? Teacher { get; set; }

            
    }
}
