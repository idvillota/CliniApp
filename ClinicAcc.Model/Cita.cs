using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicAcc.Model
{
    public class Cita
    {
        #region Properties

        public int Id { get; set; }

        public int CitaTypeID { get; set; }

        public virtual CitaType CitaType { get; set; }

        public int DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }
        
        public ECitaStatus Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int PatientID { get; set; }

        public virtual Patient Patient { get; set; }
        
        #endregion
    }
}
