using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace MedicalNotes.DTO


{
    public class ResponseDTO
    {
        #region Constructors

        public ResponseDTO()
        {
            this.Success = false;
        }

        #endregion
        #region Properties

        public bool Success { get; set; } 
        public string Message { get; set; } 
        public object Data { get; set; }

        #endregion
    }
}
