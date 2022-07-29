using System.Collections.Generic;

namespace MedicalNotes.Blazor.Data
{
    public class ResponseUIDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

       
    }
}
