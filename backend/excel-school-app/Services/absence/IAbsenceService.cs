using System;
using excel_school_app.DTOs.absence;

namespace excel_school_app.Services.absence
{
    public interface IAbsenceService
    {
         IEnumerable<AbsenceDto> GetAllAbsence();
        AbsenceDto GetAbsenceById(int id);
        AbsenceDto CreateAbsence(CreateAbsenceDto absence);
        AbsenceDto UpdateAbsence(int id, JustifyAbsenceDto absence);
        void DeleteAbsence(int id);
        IEnumerable<AbsenceDto> GetFilteredAbsence(DateOnly? date, int? studentId,Enums.AbsenceStatus? status);
    }
}
