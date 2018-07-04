using ClinicAcc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;

namespace ClinicApp.Controllers
{
    public class CitaController : BaseController
    {
        #region Fields
        
        #endregion

        #region Properties
        
        #endregion

        // GET api/Cita  
        [System.Web.Http.ActionName("get"), System.Web.Http.HttpGet]
        public IEnumerable<Cita> Citas()
       {    
            IEnumerable<Cita> citas = UnitOfWork.CitaRepository.Get(null, null, string.Empty);
           
            return citas;
        }
        // GET api/Cita/5  
        public Cita Get(int id)
        {
            Cita cita = UnitOfWork.CitaRepository.GetByID(id);

            return cita;
        }
        // POST api/Cita  
        public HttpResponseMessage Post(Cita cita)
        {
            if (ModelState.IsValid)
            {
                if (this.ValidateCita(cita).Equals(string.Empty))
                {
                    UnitOfWork.CitaRepository.Insert(cita);
                    UnitOfWork.Save();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cita);
                    return response;
                }else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        private string ValidateCita(Cita cita)
        {
            Expression<Func<Cita, bool>> filter = c => c.Patient == cita.Patient
                                                    && c.Date.Day == cita.Date.Day
                                                    && c.Date.Month == cita.Date.Month
                                                    && c.Date.Year == cita.Date.Year;

            List<Cita> citas = UnitOfWork.CitaRepository.Get(filter, null, string.Empty).ToList();

            if (null != citas || citas.Any())
            {
                return "Paciente con cita asignada para esa fecha";
            }
            

            return string.Empty;
        }

        // PUT api/Cita/5  
        public HttpResponseMessage Put(Cita cita)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CitaRepository.Update(cita);
                UnitOfWork.Save();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, cita);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/Cita/5  
        public HttpResponseMessage Delete(int id)
        {
            Cita emp = UnitOfWork.CitaRepository.GetByID(id);
            if (emp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            UnitOfWork.CitaRepository.Delete(id);
            UnitOfWork.Save();
            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }
    }
}