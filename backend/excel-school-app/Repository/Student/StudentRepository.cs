using System;
using excel_school_app.Data;
using excel_school_app.DTOs;
using excel_school_app.Models;
using Microsoft.EntityFrameworkCore;


namespace excel_school_app.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

      public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
      
      
        public Student CreateStudent(CreateStudentDto student)
        {
            var createNewStudentDto = new Student
            {
                UserId = student.UserId,
                ClasseId = student.ClasseId,
                ParentId = student.ParentId,
                Name = student.Name,
                Firstname = student.Firstname,
                StudentNumber = student.StudentNumber,
                BirthDate = student.BirthDate,
            };
            //ajouter un eleve dans le tableau student
             _appDbContext.Student
             .Add(createNewStudentDto);
            // sauvegarder l'eleve en base de donnée
            _appDbContext.SaveChanges();
            // retourner un eleve
            return createNewStudentDto;
        }

        public void DeleteStudent(int id)
        {
            // recuperer un eleve 
            var student = _appDbContext.Student.Find(id);
            //si l'eleve n'existe pas retourner une erreur
            if (student == null)
            {
                throw new Exception("L'eleve n'existe pas");
            }
            // supprimer l'utilisateur
            _appDbContext.Student.Remove(student);
            // sauvegarde les changements en DB
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            //recuperer tous les eleves 
            var students = _appDbContext.Student
            .Include(s => s.Class) // Quand tu récupères les Students, charge aussi les données liées.
            .Include(s => s.Parent)
            .ToList();
            // retourner tous les eleves
            return students;
        }

        public Student GetStudentById(int id)
        {
            // recuperer un eleve 
            var student = _appDbContext.Student.Find(id);

            // si student n'existe pas retourne une erreur
            if (student == null)
            {
                throw new Exception("L'éleve n'existe pas");

            }

            return student;
         
        }

        public Student UpdateStudent(int id, UpdateStudentDto student)
        {
            //trouver l'elever via son id
            var studentFound = _appDbContext.Student.Find(id);

            //si l'eleve n'existe pas retourner une erreur
            if(studentFound == null)
            {
                throw new Exception("L'eleve n'exite pas");
            }
            //mise à jour de l'eleve
            studentFound.UserId = student.UserId;
            studentFound.ClasseId = student.ClasseId;
            studentFound.ParentId = student.ParentId;
            studentFound.Name = student.Name;
            studentFound.Firstname = student.Firstname;
            studentFound.StudentNumber = student.StudentNumber;
            studentFound.BirthDate = student.BirthDate;

            //Ajouter la mise à jour au Student
            _appDbContext.Student.Update(studentFound);

            //Sauvegarder la mise à jour 
            _appDbContext.SaveChanges();

            // retourner un eleve 
            return studentFound;
        }
    }
}
