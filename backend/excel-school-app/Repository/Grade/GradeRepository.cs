using System;
using System.Linq.Expressions;
using excel_school_app.Data;
using excel_school_app.DTOs.Grade;
using excel_school_app.Models;

namespace excel_school_app.Repository
{
    public class GradeRepository : IGradeRepository
    {
        public readonly AppDbContext _appDbContext;

        public GradeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Grade CreateGrade(CreateGradeDto grade)
        {
            // créer un objet grade
            var newGrade = new Grade
            {
                StudentId = grade.StudentId,
                TeacherId = grade.TeacherId,
                Subject = grade.Subject,
                Value = grade.Value,
                Appreciation = grade.Appreciation,
                ExamDate = grade.ExamDate,
                Term = grade.Term,
            };

            //ajouter ma note dans ma DB
            _appDbContext.Grade.Add(newGrade);
            // sauvegarder la note 
            _appDbContext.SaveChanges();
            // retourner la note
            return newGrade;
        }

        public void DeleteGrade(int id)
        {
            //Trouver la node que via son id
            var grade = _appDbContext.Grade.Find(id);
            //Si la note n'existe pas retourner ce message d'erreur
            if (grade == null)
            {
                throw new Exception("La note n'existe pas");
            }
            //supprimer la note 
            _appDbContext.Grade.Remove(grade);
            //sauvegarde la modification
            _appDbContext.SaveChanges();

        }

        public IEnumerable<Grade> GetAllGrades()
        {
            // recuperer tous les notes
            return _appDbContext.Grade.ToList();
        }

        public IEnumerable<Grade> GetAverageByStudentId(int studentId)
        {
            //Récupérer toutes les notes de l'élève
            var listGradeStudent = _appDbContext.Grade.Where(s => s.StudentId == studentId).ToList();
            // Retourner la liste des notes de l'élèves
            return listGradeStudent;
        }

        public Grade GetGradeById(int id)
        {
            // recuperer la note via à son id
            var grade = _appDbContext.Grade.Find(id);
            //Si la grade n'existe pas retourner ce message d'erreur
            if (grade == null)
            {
                throw new Exception("La note n'existe pas");
            }
            return grade;
        }

        public IEnumerable<Grade> GetGradesByStudentId(int studentId)
        {
            // trpouver la Liste des notes des eleves
            var listGradeStudent = _appDbContext.Grade.Where(s => s.StudentId == studentId).ToList();
            //retourner la liste 
            return listGradeStudent;

        }

        public Grade UpdateGrade(int id, UpdateGradeDto grade)
        {
            // recuperer la note via son id
            var newGrade = _appDbContext.Grade.Find(id);
            //Si la grade n'existe pas retourner ce message d'erreur
            if (newGrade == null)
            {
                throw new Exception("La note n'existe pas");
            }

            // Mettre à jour ma note
            newGrade.Subject = grade.Subject;
            newGrade.Value = grade.Value;
            newGrade.Appreciation = grade.Appreciation;
            newGrade.ExamDate = grade.ExamDate;
            newGrade.Term = grade.Term;

            // sauvegarder dans la DB
            _appDbContext.SaveChanges();
            //retourner la mise à jour
            return newGrade;
        }

        public IEnumerable<Grade> GetFilteredGrades(int? studentId,Enums.Subject? subject,Enums.Term? term)
        {
            var query = _appDbContext.Grade.AsQueryable();
            // Filtrer par élève si le paramètre est fourni
            if (studentId.HasValue)
                query = query.Where(g => g.StudentId == studentId.Value);
            // Filtrer par Matiere si le paramètre est fourni
            if (subject.HasValue)
                query = query.Where(g => g.Subject == subject);
            //// Filtrer par Trimestre si le paramètre est fourni
            if (term.HasValue)
                query = query.Where(g => g.Term == term);

            return query.ToList();
        }
    }
    

}
