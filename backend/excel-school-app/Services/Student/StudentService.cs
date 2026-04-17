using System;
using System.Linq.Expressions;
using excel_school_app.Data;
using excel_school_app.DTOs;
using excel_school_app.Models;
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

            //Appeler le repository qui retourner mon entité student
            var cretedStudent = _studentRepository.CreateStudent(student);

            // convertir mon student en studentDTO
            var newStudentDto = new StudentDto
            {
                Id = cretedStudent.Id,
                UserId = cretedStudent.UserId,
                ClassName = cretedStudent.Class?.Name!,
                ParentName = cretedStudent.Parent?.Name!,
                Name = cretedStudent.Name,
                Firstname = cretedStudent.Firstname,
                StudentNumber = cretedStudent.StudentNumber,
                BirthDate = cretedStudent.BirthDate
            };
            // retourner mon StudentS
            return newStudentDto;
        }

        public void DeleteStudent(int id)
        {
            //Recuperer le repository
            _studentRepository.DeleteStudent(id);

        }

        public IEnumerable<StudentDto> GetAllStudents()
        {
            //retourner tous les eleves
            var students = _studentRepository.GetAllStudents().Select(s =>
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
            //Appeler mon repository qui retourner mon entité Student
            var student = _studentRepository.GetStudentById(id);

            //Convertir mon student en studentDTO
            var studentDto = new StudentDto
            {
                Id = student.Id,
                UserId = student.UserId,
                ClassName = student.Class?.Name!,
                ParentName = student.Parent?.Name!,
                Name = student.Name,
                Firstname = student.Firstname,
                StudentNumber = student.StudentNumber,
                BirthDate = student.BirthDate
            };
            //Retourner StudentDto
            return studentDto;
        }

        public StudentDto UpdateStudent(int id, UpdateStudentDto student)
        {
            //Recuperer le repository qui va me retourner mon entité Student
            var newStudent = _studentRepository.UpdateStudent(id, student);

            //Convertir mon student en StudentDto
            var studentDto = new StudentDto
            {
                Id = newStudent.Id,
                UserId = newStudent.UserId,
                ClassName = newStudent.Class?.Name!,
                ParentName = newStudent.Parent?.Name!,
                Name = newStudent.Name,
                Firstname = newStudent.Firstname,
                StudentNumber = newStudent.StudentNumber,
                BirthDate = newStudent.BirthDate
            };
            // retourner StudentDto
            return studentDto;
        }
    }
}
