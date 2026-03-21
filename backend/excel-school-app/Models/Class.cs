using System;

namespace excel_school_app.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;


        // navigation properties inverses indique que une classe ont plusieurs eleves
        public ICollection<Student>? Students { get; set; }

        // navigation properties inverses indique que une classe peuvent avoir plusieurs cours
        public ICollection<Lesson>? Lessons { get; set; }

        // navigation properties inverses indique que une classe peuvent avoir plusieurs ClassSubjects

        public ICollection<ClassSubject>? ClassSubjects { get; set; }
  
    }
}
