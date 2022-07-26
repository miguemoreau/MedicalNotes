using System;
using System.Collections.Generic;

#nullable disable

namespace MedicalNotes.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public string Recipe { get; set; }
        public bool? Reminder { get; set; }
        public string DoctorInfo { get; set; }
    }
}
