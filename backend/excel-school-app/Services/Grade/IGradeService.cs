using System;
using excel_school_app.DTOs.Grade;

namespace excel_school_app.Services.Grade
{
    public interface IGradeService
    {
        
        IEnumerable<GradeDto> GetAllGrades();
        GradeDto GetGradeById(int id);
        GradeDto CreateGrade(CreateGradeDto grade);
        GradeDto UpdateGrade(int id,  UpdateGradeDto grade);
        void DeleteGrade(int id);
    }
}
