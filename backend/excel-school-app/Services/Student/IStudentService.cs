using System;
using excel_school_app.DTOs;

namespace excel_school_app.Services
{
    public interface IStudentService
    {
        
        IEnumerable<StudentDto> GetAllStudent();
        StudentDto GetStudentById(int id);
        StudentDto CreateStudent(CreateStudentDto student);
        StudentDto UpdateStudent(int id,  UpdateStudentDto student);
        void DeleteStudent(int id);
    }
}
