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
        public async Task<AbsenceDto> CreateAbsence(CreateAbsenceDto absence)
        {
            var absenceDto = await _absenceRepository.CreateAbsence(absence);

            var createAbsenceDto =  new AbsenceDto
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
            var unjustifiedAbsenceCount = await _absenceRepository.CountUnjustifiedAbsences(absenceDto.StudentId);
    
            if (unjustifiedAbsenceCount >= 3)
            {
                createAbsenceDto.AlertMessage = $"Attention : l'élève a {unjustifiedAbsenceCount} absences non justifiées !";
            }           
            return createAbsenceDto;
        }

        public async Task DeleteAbsence(int id)
        {
           await _absenceRepository.DeleteAbsence(id);
        }

        public async Task<AbsenceDto> GetAbsenceById(int id)
        {
            var absence = await _absenceRepository.GetAbsenceById(id);
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

        public async Task<IEnumerable<AbsenceDto>> GetAllAbsence()
        {
            var absence = await _absenceRepository.GetAllAbsence();
            return absence.Select(a =>
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
        }

        public async Task<IEnumerable<AbsenceDto>> GetFilteredAbsence(DateOnly? date, int? studentId, AbsenceStatus? status)
        {
            var filteredListGrades = await _absenceRepository.GetFilteredAbsence(date, studentId, status);
             return filteredListGrades.Select(a =>
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
        }

        public async Task<AbsenceDto> UpdateAbsence(int id, JustifyAbsenceDto absence)
        {
            var newAbsence = await _absenceRepository.UpdateAbsence(id, absence);

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
