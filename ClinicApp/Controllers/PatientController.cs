using ClinicAcc.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ClinicApp.Controllers
{
    public class PatientController : BaseController
    {   

        // GET api/Patient  
        [System.Web.Http.ActionName("get"), System.Web.Http.HttpGet]
        public IEnumerable<Patient> Patients()
       {
            IEnumerable<Patient> patients = UnitOfWork.PatientRepository.Get(null, null, string.Empty);

            return patients;
        }
        // GET api/Patient/5  
        public Patient Get(int id)
        {
            Patient patient = UnitOfWork.PatientRepository.GetByID(id);

            return patient;
        }
        // POST api/Patient  
        public HttpResponseMessage Post(Patient patient)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.PatientRepository.Insert(patient);
                UnitOfWork.Save();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, patient);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // PUT api/Patient/5  
        public HttpResponseMessage Put(Patient patient)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.PatientRepository.Update(patient);
                UnitOfWork.Save();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, patient);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/Patient/5  
        public HttpResponseMessage Delete(int id)
        {
            Patient emp = UnitOfWork.PatientRepository.GetByID(id);
            if (emp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            UnitOfWork.PatientRepository.Delete(id);
            UnitOfWork.Save();
            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }
    }
}