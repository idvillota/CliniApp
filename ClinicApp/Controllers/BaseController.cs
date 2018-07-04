using ClinicApp.Data.Infrastructure;
using System.Web.Http;
using System.Web.Mvc;

namespace ClinicApp.Controllers
{
    public class BaseController : ApiController
    {
        #region Fields

        internal UnitOfWork UnitOfWork = new UnitOfWork();

        #endregion

        #region Properties

        protected override void Dispose(bool disposing)
        {
            UnitOfWork.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
    
}