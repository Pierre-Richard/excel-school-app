using System;
using excel_school_app.DTOs.Classes;
using excel_school_app.Models;

namespace excel_school_app.Services.Classes
{
    public interface IClassService
    {
        IEnumerable<ClassDto>GetAllClasses();
    }
}
