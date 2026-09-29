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
      
      
        public async Task<Student> CreateStudent(CreateStudentDto student)
        {
            var createNewStudentDto = new Student
            {
                UserId = student.UserId,
                ClassId = student.ClassId,
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
             await _appDbContext.SaveChangesAsync();
            // retourner un eleve
            return createNewStudentDto;
        }

        public async Task DeleteStudent(int id)
        {
            // recuperer un eleve 
            var student = await _appDbContext.Student.FindAsync(id);
            //si l'eleve n'existe pas retourner une erreur
            if (student == null)
            {
                throw new Exception("L'eleve n'existe pas");
            }
            // supprimer l'utilisateur
            _appDbContext.Student.Remove(student);
            // sauvegarde les changements en DB
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            //recuperer tous les eleves 
            var students = await _appDbContext.Student
            .Include(s => s.Class) // Quand tu récupères les Students, charge aussi les données liées.
            .Include(s => s.Parent)
            .ToListAsync();
            // retourner tous les eleves
            return students;
        }

        public async Task<Student> GetStudentById(int id)
        {
            // recuperer un eleve 
            var student = await _appDbContext.Student.FindAsync(id);

            // si student n'existe pas retourne une erreur
            if (student == null)
            {
                throw new Exception("L'éleve n'existe pas");

            }

            return student;
         
        }

        public async Task<Student> UpdateStudent(int id, UpdateStudentDto student)
        {
            //trouver l'elever via son id
            var studentFound = await _appDbContext.Student.FindAsync(id);

            //si l'eleve n'existe pas retourner une erreur
            if(studentFound == null)
            {
                throw new Exception("L'eleve n'exite pas");
            }
            //mise à jour de l'eleve
            studentFound.UserId = student.UserId;
            studentFound.ClassId = student.ClassId;
            studentFound.ParentId = student.ParentId;
            studentFound.Name = student.Name;
            studentFound.Firstname = student.Firstname;
            studentFound.StudentNumber = student.StudentNumber;
            studentFound.BirthDate = student.BirthDate;
            
            //Sauvegarder la mise à jour 
            await _appDbContext.SaveChangesAsync();

            // retourner un eleve 
            return studentFound;
        }
    }
}
