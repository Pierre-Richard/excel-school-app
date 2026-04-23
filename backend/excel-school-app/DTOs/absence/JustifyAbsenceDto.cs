using System;

namespace excel_school_app.DTOs.absence
{
    public class JustifyAbsenceDto
    {
         public string Reason { get; set; } = string.Empty;
         public Enums.AbsenceStatus Status { get; set; } 
    }
}
