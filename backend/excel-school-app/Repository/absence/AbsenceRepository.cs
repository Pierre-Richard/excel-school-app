using System;
using System.Linq.Expressions;
using excel_school_app.Data;
using excel_school_app.DTOs.absence;
using excel_school_app.Enums;
using excel_school_app.Models;
using Microsoft.EntityFrameworkCore;

namespace excel_school_app.Repository.absence
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly AppDbContext _appDbContext;

        public AbsenceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Absence> CreateAbsence(CreateAbsenceDto absence)
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
            await _appDbContext.SaveChangesAsync();
            // retourner la Absence
            return newAbsence;
        }

        public async Task DeleteAbsence(int id)
        {
            //trouver l'absence à supprimé
            var absence = await _appDbContext.Absence.FindAsync(id);
            if (absence == null)
            {
                throw new Exception("Cette absence n'existe pas");
            }
            //supprimer l'absence
            _appDbContext.Absence.Remove(absence);

            //sauvegarder le changement 

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Absence> GetAbsenceById(int id)
        {
              // recuperer la note via à son id
            var absence = await _appDbContext.Absence.FindAsync(id);
            //Si la grade n'existe pas retourner ce message d'erreur
            if (absence == null)
            {
                throw new Exception("Cette absence n'existe pas");
            }
            return absence;
        }

        public async Task<IEnumerable<Absence>> GetAllAbsence()
        {
            //recuperer la liste des absences
            var listeOfAbsence = await _appDbContext.Absence.ToListAsync();
            // retourner la liste
            return listeOfAbsence;
        }

        public async Task<IEnumerable<Absence>> GetFilteredAbsence(DateOnly? date, int? studentId, Enums.AbsenceStatus? status)
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

            return await query.ToListAsync();
        }

        public async Task<Absence> UpdateAbsence(int id, JustifyAbsenceDto absence)
        {
            //Recuperer mon absence
            var newAbsence = await _appDbContext.Absence.FindAsync(id);
            // Si l'absence n'existe pas retourner un message d'erreur
            if (newAbsence == null)
            {
                throw new Exception("Cette absence n'existe pas");
            }
            //Mise à jour de l'absence
            newAbsence.Reason = absence.Reason;
            newAbsence.Status = absence.Status;

            //sauvegarde
            await _appDbContext.SaveChangesAsync();

            //retourner la mise à jour

            return newAbsence;
        }

       public async  Task<int> CountUnjustifiedAbsences(int studentId)
        {
            return await _appDbContext.Absence
                    .Where(a => a.StudentId == studentId && a.Status == AbsenceStatus.Unjustified)
                    .CountAsync();
        }
    }
}
