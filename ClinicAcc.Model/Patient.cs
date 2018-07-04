using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicAcc.Model
{
    public class Patient
    {
        #region Properties

        public int Id { get; set; }

        public string DocumentNumber { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        #endregion
    }
}
