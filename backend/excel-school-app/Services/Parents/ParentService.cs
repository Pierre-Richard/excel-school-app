using System;
using excel_school_app.DTOs.Parents;
using excel_school_app.Repository;
using Microsoft.EntityFrameworkCore;

namespace excel_school_app.Services.Parents
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;

        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        public async Task<IEnumerable<ParentDto>> GetAllParents()
        {
            //recuperer tous les parents via le repository
            var parents = await _parentRepository.GetAllParents().Select(p => new ParentDto
            {
                Id = p.Id,
                Name = p.Name,
                Firstname = p.Firstname,
            }).ToListAsync();

            //retourner la liste des ParentDto
            return parents;
        }
    }
}
