using System;


namespace excel_school_app.DTOs.Grade
{
    public class CreateGradeDto
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public Enums.Subject Subject { get; set; }
        public int Value { get; set; }
        public string Appreciation { get; set; } = string.Empty;
        public DateOnly ExamDate { get; set; }
        public Enums.Term Term { get; set; }

    }
}
