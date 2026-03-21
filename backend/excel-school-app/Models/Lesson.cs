using System;

namespace excel_school_app.Models
{
    public class Lesson
    {
         public int Id { get; set; }
         public int TeacherId { get; set; }
         public int SubjectId { get; set; }
         public int ClassId { get; set; }
         public int RoomId { get; set; }
         public DateOnly Day { get; set; } 
         public TimeOnly StartTime { get; set; } 
         public TimeOnly EndTime { get; set; } 

         // Navigation property indique les relations entre models
         public Teacher? Teacher { get; set; }
         public Subject? Subject { get; set; }
         public Class? Class { get; set; }
         public Room? Room { get; set; }


    }
}
