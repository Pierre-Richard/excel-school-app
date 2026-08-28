using System;
using excel_school_app.DTOs.absence;
using excel_school_app.Models;

namespace excel_school_app.Repository.absence
{
    public interface IAbsenceRepository
    {
        Task<IEnumerable<Absence>> GetAllAbsence();
        Task<Absence> GetAbsenceById(int id);
        Task<Absence> CreateAbsence(CreateAbsenceDto absence);
        Task<Absence> UpdateAbsence(int id, JustifyAbsenceDto absence);
        Task DeleteAbsence(int id);
        Task<IEnumerable<Absence>> GetFilteredAbsence(DateOnly? date, int? studentId, Enums.AbsenceStatus? status);
         Task<int> CountUnjustifiedAbsences(int studentId);
    }
}
