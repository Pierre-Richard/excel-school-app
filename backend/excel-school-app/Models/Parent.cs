using System;


namespace excel_school_app.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        ///navigation properties inverses un parent peut avoir plusieurs parentTeachers
        public ICollection<ParentTeacher>? ParentTeachers { get; set; }
         
    }
}
