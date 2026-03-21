using System;

namespace excel_school_app.Models
{
    public class ParentTeacher
    {
        public int ParentId { get; set; }
        public int TeacherId { get; set; }

         // Navigation property indique les relations entre models
        public Parent? Parent { get; set; }
        public Teacher? Teacher { get; set; }
 
    }
}
