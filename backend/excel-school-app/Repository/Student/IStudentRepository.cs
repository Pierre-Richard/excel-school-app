using System;
using excel_school_app.DTOs;
using excel_school_app.Models;

namespace excel_school_app.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(CreateStudentDto student);
        Task<Student> UpdateStudent(int id,  UpdateStudentDto student);
        Task DeleteStudent(int id);
        
    }
}
