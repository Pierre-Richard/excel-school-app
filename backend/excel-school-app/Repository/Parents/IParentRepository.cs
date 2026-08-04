using System;
using excel_school_app.Models;

namespace excel_school_app.Repository
{
    public interface IParentRepository
    {
        IQueryable<Parent> GetAllParents();
    }
}
