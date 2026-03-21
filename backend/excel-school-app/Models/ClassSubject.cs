using System;


namespace excel_school_app.Models
{
    public class ClassSubject
    {
        public int ClassId { get; set; }
        public int SubjectId { get; set; }

        // Navigation property
         public  Class? Class { get; set; }
         public  Subject? Subject { get; set; }

    }
}
