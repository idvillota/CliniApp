namespace ClinicApp.Data.Migrations
{
    using ClinicAcc.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClinicApp.Data.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private void GenerateDoctor(DBContext context)
        {
            context.Doctors.AddOrUpdate(
                d => d.DocumentNumber,
                new Doctor
                {
                    DocumentNumber = "15313545",
                    FirstName = "Luis Fernando",
                    LastName = "Moreno",
                    PhoneNumber = "3015463848"
                },
                new Doctor
                {
                    DocumentNumber = "1351354",
                    FirstName = "Sandra",
                    LastName = "Suarez",
                    PhoneNumber = "31845454"
                },
                new Doctor
                {
                    DocumentNumber = "351354",
                    FirstName = "Carlos",
                    LastName = "Sanchez",
                    PhoneNumber = "302135135"
                }
                );
        }

        private void GenerateCitaTypes(DBContext context)
        {
            context.CitaTypes.AddOrUpdate(
                ct => ct.Name,
                new CitaType
                {
                    Name = "Medicina General",
                    Description = "Medicina General Descripción"
                },
                new CitaType
                {
                    Name = "Odontología",
                    Description = "Odontología Descripción"
                },
                new CitaType
                {
                    Name = "Pediatría",
                    Description = "Pediatría Descripción"
                },
                new CitaType
                {
                    Name = "Neurología",
                    Description = "Neurología Descripción"
                });
        }

        private void GeneratePatients(DBContext context)
        {
            context.Patients.AddOrUpdate(
                p => p.DocumentNumber,
                new Patient
                {
                    DocumentNumber = "11111111",
                    FirstName = "Ivan Dario",
                    LastName = "Villota",
                    Address = "Calle 16 no 35 - 27",
                    PhoneNumber = "3043862713",
                    Birth = new System.DateTime(1983, 05, 14)
                },
                new Patient
                {
                    DocumentNumber = "222222",
                    FirstName = "Maria Helena",
                    LastName = "Diaz",
                    Address = "Cra. 35 no 25 - 12",
                    PhoneNumber = "3001234567",
                    Birth = new System.DateTime(1990, 08, 05)
                },
                new Patient
                {
                    DocumentNumber = "3333333",
                    FirstName = "Gabriel",
                    LastName = "Villota",
                    Address = "Calle 36 no 32 - 8",
                    PhoneNumber = "3009876543",
                    Birth = new System.DateTime(1945, 09, 28)
                },
                new Patient
                {
                    DocumentNumber = "444444444",
                    FirstName = "Sasha",
                    LastName = "Uribe",
                    Address = "Cra 45 no 36 - 84",
                    PhoneNumber = "301154876",
                    Birth = new System.DateTime(2000, 04, 13)
                }
                );
        }

        protected override void Seed(DBContext context)
        {
            this.GenerateDoctor(context);

            this.GeneratePatients(context);

            this.GenerateCitaTypes(context);

            context.SaveChanges();
        }
    }
}
