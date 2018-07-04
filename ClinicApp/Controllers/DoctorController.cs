using ClinicAcc.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace ClinicApp.Controllers
{
    public class DoctorController : BaseController
    {   

        // GET api/Doctor  
        [System.Web.Http.ActionName("get"), System.Web.Http.HttpGet]
        public IEnumerable<Doctor> Doctors()
        {
            IEnumerable<Doctor> doctors = UnitOfWork.DoctorRepository.Get(null, null, string.Empty);

            return doctors;
        }
        // GET api/Doctor/5  
        public Doctor Get(int id)
        {
            Doctor doctor = UnitOfWork.DoctorRepository.GetByID(id);

            return doctor;
        }
        // POST api/Doctor  
        public HttpResponseMessage Post(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.DoctorRepository.Insert(doctor);
                UnitOfWork.Save();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, doctor);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // PUT api/Doctor/5  
        public HttpResponseMessage Put(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.DoctorRepository.Update(doctor);
                UnitOfWork.Save();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, doctor);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/Doctor/5  
        public HttpResponseMessage Delete(int id)
        {
            Doctor emp = UnitOfWork.DoctorRepository.GetByID(id);
            if (emp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            UnitOfWork.DoctorRepository.Delete(id);
            UnitOfWork.Save();
            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }

        ////[System.Web.Http.ActionName("GetForSelect"), System.Web.Http.HttpGet]
        //[HttpGet]
        //[Route("Doctor/xxxx")]
        //public IEnumerable<SelectListItem> xxxx()
        //{
        //    List<SelectListItem> doctors = new List<SelectListItem>();

        //    foreach (Doctor doctor in this.Doctors())
        //    {
        //        doctors.Add(new SelectListItem
        //        {
        //            Text = doctor.FirstName + " " + doctor.LastName,
        //            Value = doctor.Id.ToString()
        //        });
        //    }

        //    return doctors;
        //}
    }
}