using System;
using System.Linq.Expressions;
using excel_school_app.Data;
using excel_school_app.DTOs.absence;
using excel_school_app.Enums;
using excel_school_app.Models;

namespace excel_school_app.Repository.absence
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly AppDbContext _appDbContext;

        public AbsenceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Absence CreateAbsence(CreateAbsenceDto absence)
        {
            // créer un objet Absence
            var newAbsence = new Absence
            {
                StudentId = absence.StudentId,
                Date = absence.Date,
                StartTime = absence.StartTime,
                EndTime = absence.EndTime,
                Reason = absence.Reason,
                Status = absence.Status,
                IsFullDay = absence.IsFullDay,
                CreatedAt = DateTime.UtcNow,
            };
            //ajouter ma Absence dans ma DB
            _appDbContext.Absence.Add(newAbsence);
            // sauvegarder la Absence 
            _appDbContext.SaveChanges();
            // retourner la Absence
            return newAbsence;
        }

        public void DeleteAbsence(int id)
        {
            //trouver l'absence à supprimé
            var absence = _appDbContext.Absence.Find(id);
            if (absence == null)
            {
                throw new Exception("Cette absence n'existe pas");
            }
            //supprimer l'absence
            _appDbContext.Absence.Remove(absence);

            //sauvegarder le changement 

            _appDbContext.SaveChanges();
        }

        public Absence GetAbsenceById(int id)
        {
              // recuperer la note via à son id
            var absence = _appDbContext.Absence.Find(id);
            //Si la grade n'existe pas retourner ce message d'erreur
            if (absence == null)
            {
                throw new Exception("Cette absence n'existe pas");
            }
            return absence;
        }

        public IEnumerable<Absence> GetAllAbsence()
        {
            //recuperer la liste des absences
            var listeOfAbsence = _appDbContext.Absence.ToList();
            // retourner la liste
            return listeOfAbsence;
        }

        public IEnumerable<Absence> GetFilteredAbsence(DateOnly? date, int? studentId, Enums.AbsenceStatus? status)
        {
            var query = _appDbContext.Absence.AsQueryable();
            // Filtrer par date si le paramètre est fourni
            if (date.HasValue)
                query = query.Where(g => g.Date == date.Value);
            // Filtrer par eleve si le paramètre est fourni
            if (studentId.HasValue)
                query = query.Where(g => g.StudentId == studentId.Value);
            //// Filtrer par status si le paramètre est fourni
            if (status.HasValue)
                query = query.Where(g => g.Status == status);

            return query.ToList();
        }

        public Absence UpdateAbsence(int id, JustifyAbsenceDto absence)
        {
            //Recuperer mon absence
            var newAbsence = _appDbContext.Absence.Find(id);
            // Si l'absence n'existe pas retourner un message d'erreur
            if (newAbsence == null)
            {
                throw new Exception("Cette absence n'existe pas");
            }
            //Mise à jour de l'absence
            newAbsence.Reason = absence.Reason;
            newAbsence.Status = absence.Status;

            //sauvegarde
            _appDbContext.SaveChanges();

            //retourner la mise à jour

            return newAbsence;
        }
    }
}
