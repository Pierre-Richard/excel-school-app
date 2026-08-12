using System;
using excel_school_app.Data;
using excel_school_app.Models;

namespace excel_school_app.Repository.Classes
{
    public class ClassRepository : IClassRepository
    {

        private readonly AppDbContext _appDbContext;

        public ClassRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Class> GetAllClasses()
        {
            // recuperer tous les classes de la Db
            var classes = _appDbContext.Class;
            // return les classes
            return classes;
        }
    }
}
