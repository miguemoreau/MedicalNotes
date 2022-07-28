using System;

namespace MedicalNotes.Blazor.Data
{
    public class Request
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorInfo { get; set; }
        public string Recipe { get; set; }
        public string Diagnosis { get; set; }
        public bool Reminder { get; set; }
        public DateTime Date { get; set; }

    }
}
