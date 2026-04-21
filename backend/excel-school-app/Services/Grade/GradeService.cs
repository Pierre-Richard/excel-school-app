using System;
using excel_school_app.DTOs.Grade;
using excel_school_app.Repository;

namespace excel_school_app.Services.Grade
{
    public class GradeService : IGradeService

    {
        private readonly IGradeRepository _gradeRepository;
        
        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public GradeDto CreateGrade(CreateGradeDto grade)
        {
            var gradeDto = _gradeRepository.CreateGrade(grade);

            var createGradeDto = new GradeDto
            {
                Id = gradeDto.Id,
                StudentId = gradeDto.StudentId,
                TeacherId = gradeDto.TeacherId,
                Subject = gradeDto.Subject,
                Value = gradeDto.Value,
                Appreciation = gradeDto.Appreciation,
                ExamDate = gradeDto.ExamDate,
                Term = gradeDto.Term
            };

            return createGradeDto;
        }

        public void DeleteGrade(int id)
        {
            _gradeRepository.DeleteGrade(id);
        }

        public IEnumerable<GradeDto> GetAllGrades()
        {
            var grades = _gradeRepository.GetAllGrades().Select(grade =>
              {
                  return new GradeDto
                  {
                      Id = grade.Id,
                      StudentId = grade.StudentId,
                      TeacherId = grade.TeacherId,
                      Subject = grade.Subject,
                      Value = grade.Value,
                      Appreciation = grade.Appreciation,
                      ExamDate = grade.ExamDate,
                      Term = grade.Term
                  };
              });

            return grades;
        }

        public GradeDto GetGradeById(int id)
        {
            var grade = _gradeRepository.GetGradeById(id);
            var newGrade = new GradeDto
            {
                Id = grade.Id,
                StudentId = grade.StudentId,
                TeacherId = grade.TeacherId,
                Subject = grade.Subject,
                Value = grade.Value,
                Appreciation = grade.Appreciation,
                ExamDate = grade.ExamDate,
                Term = grade.Term
            };

            return newGrade;
        }

        public GradeDto UpdateGrade(int id, UpdateGradeDto grade)
        {
            var newGrade = _gradeRepository.UpdateGrade(id, grade);

            var updateGrade = new GradeDto
            {
                Id = newGrade.Id,
                StudentId = newGrade.StudentId,
                TeacherId = newGrade.TeacherId,
                Subject = newGrade.Subject,
                Value = newGrade.Value,
                Appreciation = newGrade.Appreciation,
                ExamDate = newGrade.ExamDate,
                Term = newGrade.Term
            };

            return updateGrade;
        }
    }
}
