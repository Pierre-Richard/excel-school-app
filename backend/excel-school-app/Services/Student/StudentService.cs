using System;
using excel_school_app.Data;
using excel_school_app.DTOs;
using excel_school_app.Repository;

namespace excel_school_app.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public StudentDto CreateStudent(CreateStudentDto student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentDto> GetAllStudent()
        {
            //retourner tous les eleves
            var students = _studentRepository.GetAllStudent().Select(s =>
            {
                return new StudentDto
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    ClassName = s.Class?.Name!,
                    ParentName = s.Parent?.Name!,
                    Name = s.Name,
                    Firstname = s.Firstname,
                    StudentNumber = s.StudentNumber,
                    BirthDate = s.BirthDate,
                };
            });

            return students;
     
        }

        public StudentDto GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public StudentDto UpdateStudent(int id, UpdateStudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
