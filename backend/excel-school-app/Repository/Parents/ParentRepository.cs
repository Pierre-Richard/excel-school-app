using System;
using excel_school_app.Data;
using excel_school_app.DTOs.Parents;
using excel_school_app.Models;
using Microsoft.EntityFrameworkCore;

namespace excel_school_app.Repository
{
    public class ParentRepository : IParentRepository
    {

        private readonly AppDbContext _appDbContext;

        public ParentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<Parent> GetAllParents()
        {
            //recuperer tous les parents de la db 
            var parents = _appDbContext.Parent;
            // retourner les parents 
            return parents;
        }

    }
}
