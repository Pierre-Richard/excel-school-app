using System;

namespace excel_school_app.DTOs
{
    public class UpdateStudentDto
    {
         public int UserId { get; set; }
          public int ClassId { get; set; }
          public int ParentId { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Firstname { get; set; } = string.Empty; 
          public int StudentNumber { get; set; }
          public DateOnly BirthDate { get; set; } 
    }
}
