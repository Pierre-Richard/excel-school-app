using System;
using excel_school_app.DTOs.Grade;
using excel_school_app.Models;

namespace excel_school_app.Repository
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllGrades();
        Task<Grade> GetGradeById(int id);
        Task<Grade> CreateGrade(CreateGradeDto grade);
        Task<Grade> UpdateGrade(int id, UpdateGradeDto grade);
        Task<IEnumerable<Grade>> GetGradesByStudentId(int studentId);
        Task<IEnumerable<Grade>> GetFilteredGrades(int? studentId, Enums.Subject? subject, Enums.Term? term);
        Task DeleteGrade(int id);
        
    }
}
