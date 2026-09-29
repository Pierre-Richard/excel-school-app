using System;
using excel_school_app.DTOs;

namespace excel_school_app.Services
{
    public interface IStudentService
    { 
        Task<IEnumerable<StudentDto>> GetAllStudents();
        Task<StudentDto> GetStudentById(int id);
        Task<StudentDto> CreateStudent(CreateStudentDto student);
        Task<StudentDto> UpdateStudent(int id,  UpdateStudentDto student);
        Task DeleteStudent(int id);
    }
}
