using System;

namespace excel_school_app.Models
{
    public class Teacher
    {
         public int Id { get; set; }
         public int UserId { get; set; }
         public string Name { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
         
         //navigation properties inverses un enseignant peut avoir plusieurs cours  
         
         public ICollection<Lesson>? Lessons { get; set; }

         ///navigation properties inverses un enseignant peut avoir plusieurs Parent(ParentTeacher)
         public ICollection<ParentTeacher>? ParentTeachers { get; set; }


         
    }
}
