using System;

namespace excel_school_app.DTOs
{
    public class StudentDto
    {
          public int Id { get; set; }
          public int UserId { get; set; }
          public string ClassName { get; set; } = string.Empty;
          public string ParentName { get; set; } = string.Empty;
          public string Name { get; set; } = string.Empty;
          public string Firstname { get; set; } = string.Empty; 
          public int StudentNumber { get; set; }
          public DateTime BirthDate { get; set; } 
    }
}
