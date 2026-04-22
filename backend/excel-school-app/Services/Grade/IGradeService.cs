using System;
using excel_school_app.DTOs.Grade;

namespace excel_school_app.Services.Grade
{
    public interface IGradeService
    {
        
        IEnumerable<GradeDto> GetAllGrades();
        GradeDto GetGradeById(int id);
        GradeDto CreateGrade(CreateGradeDto grade);
        GradeDto UpdateGrade(int id, UpdateGradeDto grade);
        IEnumerable<GradeDto> GetGradesByStudentId(int studentId);
        AverageDto GetAverageByStudentId(int studentId);
        IEnumerable<GradeDto> GetFilteredGrades(int? studentId, Enums.Subject? subject, Enums.Term? term);
        void DeleteGrade(int id);
    }
}
