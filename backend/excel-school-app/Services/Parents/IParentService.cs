using System;
using excel_school_app.DTOs.Parents;

namespace excel_school_app.Services.Parents
{
    public interface IParentService
    {
        IEnumerable<ParentDto> GetAllParents();
    }
}
