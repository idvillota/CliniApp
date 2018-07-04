using ClinicAcc.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ClinicApp.Controllers
{
    public class CitaTypeController : BaseController
    {   

        // GET api/CitaType  
        [System.Web.Http.ActionName("get"), System.Web.Http.HttpGet]
        public IEnumerable<CitaType> CitaTypes()
       {
            IEnumerable<CitaType> citaTypes = UnitOfWork.CitaTypeRepository.Get(null, null, string.Empty);

            return citaTypes;
        }
        // GET api/CitaType/5  
        public CitaType Get(int id)
        {
            CitaType citaType = UnitOfWork.CitaTypeRepository.GetByID(id);

            return citaType;
        }
        // POST api/CitaType  
        public HttpResponseMessage Post(CitaType citaType)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CitaTypeRepository.Insert(citaType);
                UnitOfWork.Save();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, citaType);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // PUT api/CitaType/5  
        public HttpResponseMessage Put(CitaType citaType)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CitaTypeRepository.Update(citaType);
                UnitOfWork.Save();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, citaType);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/CitaType/5  
        public HttpResponseMessage Delete(int id)
        {
            CitaType emp = UnitOfWork.CitaTypeRepository.GetByID(id);
            if (emp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            UnitOfWork.CitaTypeRepository.Delete(id);
            UnitOfWork.Save();
            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }
    }
}