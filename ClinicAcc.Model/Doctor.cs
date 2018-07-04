using System.ComponentModel.DataAnnotations;

namespace ClinicAcc.Model
{
    public class Doctor
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
        
        public string PhoneNumber { get; set; }
        
        #endregion
    }

}
