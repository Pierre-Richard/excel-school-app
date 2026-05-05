using System;
using System.Linq.Expressions;
using excel_school_app.DTOs.absence;
using excel_school_app.Enums;
using excel_school_app.Repository.absence;

namespace excel_school_app.Services.absence
{
    public class AbsenceService : IAbsenceService
    {
        private readonly IAbsenceRepository _absenceRepository;

        public AbsenceService(IAbsenceRepository absenceRepository)
        {
            _absenceRepository = absenceRepository;
        }
        public AbsenceDto CreateAbsence(CreateAbsenceDto absence)
        {
            var absenceDto = _absenceRepository.CreateAbsence(absence);

            var createAbsenceDto = new AbsenceDto
            {
                Id = absenceDto.Id,
                StudentId = absenceDto.StudentId,
                Date = absenceDto.Date,
                StartTime = absenceDto.StartTime,
                EndTime = absenceDto.EndTime,
                Reason = absenceDto.Reason,
                Status = absenceDto.Status,
                IsFullDay = absenceDto.IsFullDay,
                CreatedAt = absenceDto.CreatedAt,
            };
            var countAbsenceUnjustified = _absenceRepository.GetFilteredAbsence(null, absenceDto.StudentId, AbsenceStatus.Unjustified).Count();

            if (countAbsenceUnjustified >= 3)
            {
                createAbsenceDto.AlertMessage = $"Attention : l'élève a {countAbsenceUnjustified} absences non justifiées !";
            }
            Console.WriteLine($"Count: {countAbsenceUnjustified}");

           
            return createAbsenceDto;
        }

        public void DeleteAbsence(int id)
        {
            _absenceRepository.DeleteAbsence(id);
        }

        public AbsenceDto GetAbsenceById(int id)
        {
            var absence = _absenceRepository.GetAbsenceById(id);
            var newAbsence = new AbsenceDto
            {
                Id = absence.Id,
                StudentId = absence.StudentId,
                Date = absence.Date,
                StartTime = absence.StartTime,
                EndTime = absence.EndTime,
                Reason = absence.Reason,
                Status = absence.Status,
                IsFullDay = absence.IsFullDay,
                CreatedAt = absence.CreatedAt
            };

            return newAbsence;
        }

        public IEnumerable<AbsenceDto> GetAllAbsence()
        {
            var absence = _absenceRepository.GetAllAbsence().Select(a =>
              {
                  return new AbsenceDto
                  {
                        Id = a.Id,
                        StudentId = a.StudentId,
                        Date = a.Date,
                        StartTime = a.StartTime,
                        EndTime = a.EndTime,
                        Reason = a.Reason,
                        Status = a.Status,
                        IsFullDay = a.IsFullDay,
                        CreatedAt = a.CreatedAt
                  };
              });

            return absence;
        }

        public IEnumerable<AbsenceDto> GetFilteredAbsence(DateOnly? date, int? studentId, AbsenceStatus? status)
        {
             var filteredListGrades = _absenceRepository.GetFilteredAbsence(date, studentId, status).Select(a =>
            {
                return new AbsenceDto
                {
                    Id = a.Id,
                    StudentId = a.StudentId,
                    Date = a.Date,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    Reason = a.Reason,
                    Status = a.Status,
                    IsFullDay = a.IsFullDay,
                    CreatedAt = a.CreatedAt
                };
            });

            return filteredListGrades;
        }

        public AbsenceDto UpdateAbsence(int id, JustifyAbsenceDto absence)
        {
            var newAbsence = _absenceRepository.UpdateAbsence(id, absence);

            var updateAbsence = new AbsenceDto
            {
                        Id = newAbsence.Id,
                        StudentId = newAbsence.StudentId,
                        Date = newAbsence.Date,
                        StartTime = newAbsence.StartTime,
                        EndTime = newAbsence.EndTime,
                        Reason = newAbsence.Reason,
                        Status = newAbsence.Status,
                        IsFullDay = newAbsence.IsFullDay,
                        CreatedAt = newAbsence.CreatedAt
            };

            return updateAbsence;
        }
    }
}
