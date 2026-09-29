using System;
using excel_school_app.DTOs.Grade;

namespace excel_school_app.Services.Grade
{
    public interface IGradeService
    {
        
        Task<IEnumerable<GradeDto>> GetAllGrades();
        Task<GradeDto> GetGradeById(int id);
        Task<GradeDto> CreateGrade(CreateGradeDto grade);
        Task<GradeDto> UpdateGrade(int id, UpdateGradeDto grade);
        Task<IEnumerable<GradeDto>> GetGradesByStudentId(int studentId);
        Task<AverageDto> GetAverageByStudentId(int studentId);
        Task<IEnumerable<GradeDto>> GetFilteredGrades(int? studentId, Enums.Subject? subject, Enums.Term? term);
        Task DeleteGrade(int id);
    }
}
