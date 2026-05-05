using System;
using excel_school_app.DTOs.absence;
using excel_school_app.Models;

namespace excel_school_app.Repository.absence
{
    public interface IAbsenceRepository
    {
        IEnumerable<Absence> GetAllAbsence();
        Absence GetAbsenceById(int id);
        Absence CreateAbsence(CreateAbsenceDto absence);
        Absence UpdateAbsence(int id, JustifyAbsenceDto absence);
        void DeleteAbsence(int id);
        IEnumerable<Absence> GetFilteredAbsence(DateOnly? date, int? studentId,Enums.AbsenceStatus? status);
    }
}
