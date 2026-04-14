using System;
using excel_school_app.DTOs;
using excel_school_app.Models;

namespace excel_school_app.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int id);
        Student CreateStudent(CreateStudentDto student);
        Student UpdateStudent(int id,  UpdateStudentDto student);
        void DeleteStudent(int id);
        
    }
}
