using System;
using excel_school_app.DTOs.absence;

namespace excel_school_app.Services.absence
{
    public interface IAbsenceService
    {
        Task<IEnumerable<AbsenceDto>> GetAllAbsence();
        Task<AbsenceDto> GetAbsenceById(int id);
        Task<AbsenceDto> CreateAbsence(CreateAbsenceDto absence);
        Task<AbsenceDto> UpdateAbsence(int id, JustifyAbsenceDto absence);
        Task DeleteAbsence(int id);
        Task<IEnumerable<AbsenceDto>> GetFilteredAbsence(DateOnly? date, int? studentId, Enums.AbsenceStatus? status);
      
    }
}
