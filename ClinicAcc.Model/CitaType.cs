using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicAcc.Model
{
    public class CitaType
    {
        #region Properties

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        
        #endregion
    }
}
