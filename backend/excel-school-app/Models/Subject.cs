using System;

namespace excel_school_app.Models
{
    public class Subject
    {
         public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
         
        // navigation properties inverses que les matieres ont plusieurs cours
        public ICollection<Lesson>? Lessons { get; set; }
         
        // navigation properties inverse une matiere peut avoit plus classe(ClassSubjects)
        public ICollection<ClassSubject>? ClassSubjects { get; set; }

        
    }
}
