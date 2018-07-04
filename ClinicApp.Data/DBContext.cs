using ClinicAcc.Model;
using System.Data.Entity;

namespace ClinicApp.Data
{
    public class DBContext : DbContext
    {
        #region Properties

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<CitaType> CitaTypes { get; set; }

        #endregion

        #region Constructors


        public static DbContext Create()
        {
            return new DBContext();
        }

        public DBContext() : base("name=ClinicAppConnectionString")
        {
        }

        #endregion
    }
}
