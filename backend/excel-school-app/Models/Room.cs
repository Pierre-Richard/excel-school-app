using System;

namespace excel_school_app.Models
{
    public class Room
    {
         public int Id { get; set; }

         public string Name { get; set; } = string.Empty;

         public int Capacity { get; set; }

          ///navigation properties inverses une salle peut avoir plusieurs cours
          public ICollection<Lesson>? Lessons { get; set; }

    }
}