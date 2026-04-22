using System;
using excel_school_app.DTOs.Grade;
using excel_school_app.Models;

namespace excel_school_app.Repository
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetAllGrades();
        Grade GetGradeById(int id);
        Grade CreateGrade(CreateGradeDto grade);
        Grade UpdateGrade(int id, UpdateGradeDto grade);
        IEnumerable<Grade> GetGradesByStudentId(int studentId);
        IEnumerable<Grade> GetAverageByStudentId(int studentId);
        IEnumerable<Grade> GetFilteredGrades(int? studentId, Enums.Subject? subject, Enums.Term? term);
        void DeleteGrade(int id);
        
    }
}
