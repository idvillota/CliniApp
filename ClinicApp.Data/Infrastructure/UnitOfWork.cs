using ClinicAcc.Model;
using System;

namespace ClinicApp.Data.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        #region Fields

        private BaseRepository<Patient> myPatientRepository;

        private BaseRepository<Doctor> myDoctorRepository;

        private BaseRepository<Cita> myCitaRepository;

        private BaseRepository<CitaType> myCitaTypeRepository;

        private bool disposed = false;

        #endregion

        #region Properties

        private DBContext context = new DBContext();

        public BaseRepository<Patient> PatientRepository
        {
            get
            {
                if (this.myPatientRepository == null)
                {
                    this.myPatientRepository = new BaseRepository<Patient>(context);
                }
                return myPatientRepository;
            }
        }

        public BaseRepository<Doctor> DoctorRepository
        {
            get
            {
                if (this.myDoctorRepository == null)
                {
                    this.myDoctorRepository = new BaseRepository<Doctor>(context);
                }
                return myDoctorRepository;
            }
        }

        public BaseRepository<Cita> CitaRepository
        {
            get
            {
                if (this.myCitaRepository == null)
                {
                    this.myCitaRepository = new BaseRepository<Cita>(context);
                }
                return myCitaRepository;
            }
        }

        public BaseRepository<CitaType> CitaTypeRepository
        {
            get
            {
                if (this.myCitaTypeRepository == null)
                {
                    this.myCitaTypeRepository = new BaseRepository<CitaType>(context);
                }
                return myCitaTypeRepository;
            }
        }

        #endregion

        #region Methods

        public void Save()
        {
            context.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}