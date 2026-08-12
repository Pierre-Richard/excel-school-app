using System;
using excel_school_app.DTOs.Classes;
using excel_school_app.Models;
using excel_school_app.Repository.Classes;

namespace excel_school_app.Services.Classes
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public IEnumerable<ClassDto> GetAllClasses()
        {
            //recuperer tous les classes via le repository
            var classes = _classRepository.GetAllClasses().Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                Level = c.Level
            });
            // retourner la liste des ClassDto
            return classes;
        }
    }
}
