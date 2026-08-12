using System;
using excel_school_app.Models;

namespace excel_school_app.Repository.Classes
{
    public interface IClassRepository
    {
        IQueryable<Class> GetAllClasses();
    }
}
