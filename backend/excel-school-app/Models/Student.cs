using System;

namespace excel_school_app.Models
{
    public class Student
    {
          public int Id { get; set; }
          public int UserId { get; set; }
          public int ClasseId { get; set; }
          public int ParentId { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Firstname { get; set; } = string.Empty; 
          public int StudentNumber { get; set; }
          public DateTime BirthDate { get; set; } 
          
          // Navigation property indique les relations entre models
          public Class? Class { get; set; }
          public Parent? Parent { get; set; }
          public User? User { get; set; }
    }
}
