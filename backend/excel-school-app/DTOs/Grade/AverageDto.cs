using System;

namespace excel_school_app.DTOs.Grade
{
    public class AverageDto
    {
        public double StudentId { get; set; }
        public double GeneralAverage { get; set; }
        public List<SubjectAverageDto> AverageBySubject { get; set; } = new List<SubjectAverageDto>();
    }
}
