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

        public async Task<GradeDto> CreateGrade(CreateGradeDto grade)
        {
            var gradeDto = await _gradeRepository.CreateGrade(grade);

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

        public async Task DeleteGrade(int id)
        {
           await _gradeRepository.DeleteGrade(id);
        }

        public async Task<IEnumerable<GradeDto>> GetAllGrades()
        {
            var grades = await _gradeRepository.GetAllGrades();
            return grades.Select(grade =>
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
        }

        public async Task<AverageDto> GetAverageByStudentId(int studentId)
        {
            var listGradeOfStudent = await _gradeRepository.GetGradesByStudentId(studentId);
            //// Pas encore de note : la moyenne vaut null, pas 0.
            // 0/20 est une vraie note (l'eleve a compose et rate) ; l'absence de note n'en est pas une.
            if(!listGradeOfStudent.Any())
            {
                return new AverageDto
                {
                    StudentId = studentId,
                    GeneralAverage = null,
                    AverageBySubject =  new List<SubjectAverageDto>(),
                };
            }
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

        public async Task<IEnumerable<GradeDto>> GetFilteredGrades(int? studentId, Subject? subject, Term? term)
        {
            var filteredListGrades = await _gradeRepository.GetFilteredGrades(studentId, subject, term);
           return filteredListGrades.Select(g =>
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
            
        }

        public async Task<GradeDto> GetGradeById(int id)
        {
            var grade = await _gradeRepository.GetGradeById(id);
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

        public async Task<IEnumerable<GradeDto>> GetGradesByStudentId(int studentId)
        {
            var listeGradeStudent = await _gradeRepository.GetGradesByStudentId(studentId);
            return  listeGradeStudent.Select(g =>
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
          
        }

        public async Task<GradeDto> UpdateGrade(int id, UpdateGradeDto grade)
        {
            var newGrade = await _gradeRepository.UpdateGrade(id, grade);

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
