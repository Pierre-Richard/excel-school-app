using System;

namespace excel_school_app.DTOs
{
    public class CreateStudentDto
    {
          public int UserId { get; set; }
          public int ClasseId { get; set; }
          public int ParentId { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Firstname { get; set; } = string.Empty; 
          public int StudentNumber { get; set; }
          public DateTime BirthDate { get; set; } 
    }
}
