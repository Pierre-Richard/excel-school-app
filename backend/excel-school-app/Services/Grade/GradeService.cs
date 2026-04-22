using System;
using excel_school_app.DTOs.Grade;
using excel_school_app.Enums;
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

        public AverageDto GetAverageByStudentId(int studentId)
        {
            var listGradeOfStudent = _gradeRepository.GetAverageByStudentId(studentId);
            var average = listGradeOfStudent.Average(v => v.Value);

            var averageBySubject = listGradeOfStudent.GroupBy(v => v.Subject).Select(a =>
            {
                return new SubjectAverageDto
                {
                    Subject = a.Key,
                    Average = a.Average(g => g.Value)
                };
            });

            var newAverageDto = new AverageDto
            {
                StudentId = studentId,
                GeneralAverage = average,
                AverageBySubject = averageBySubject.ToList()
            };

            return newAverageDto;
            
        }

        public IEnumerable<GradeDto> GetFilteredGrades(int? studentId, Subject? subject, Term? term)
        {
            var filteredListGrades = _gradeRepository.GetFilteredGrades(studentId, subject, term).Select(g =>
            {
                return new GradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    TeacherId = g.TeacherId,
                    Subject = g.Subject,
                    Value = g.Value,
                    Appreciation = g.Appreciation,
                    ExamDate = g.ExamDate,
                    Term = g.Term
                };
            });

            return filteredListGrades;
            
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

        public IEnumerable<GradeDto> GetGradesByStudentId(int studentId)
        {
            var listeGradeStudent = _gradeRepository.GetGradesByStudentId(studentId).Select(g =>
            {
                return new GradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    TeacherId = g.TeacherId,
                    Subject = g.Subject,
                    Value = g.Value,
                    Appreciation = g.Appreciation,
                    ExamDate = g.ExamDate,
                    Term = g.Term
                };
            });

            return listeGradeStudent;
          
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
