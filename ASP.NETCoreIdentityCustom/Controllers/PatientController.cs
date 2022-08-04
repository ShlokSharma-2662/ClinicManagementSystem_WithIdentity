using ASP.NETCoreIdentityCustom.Data;
using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class PatientController : Controller
    {

        PatientDBAccess PDBA = new PatientDBAccess();

        public IActionResult AddPatient()
        {
            return View();
        }

        public IActionResult PatientManagement()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPatient([FromBody] PatientModel model)
        {
            {
                PDBA.AddPatient(model);

            }
            return Json(View(model));
        }

        [HttpGet]
        public JsonResult GetPatientData(string orderby, string whereclause)
        {
            List<PatientModel> ULst = new List<PatientModel>();
            ULst = PDBA.GetPatientData(orderby, whereclause);
            return Json(new { data = ULst });
            
        }

        [HttpGet]
        public JsonResult LOL(string orderby, string whereclause)
        {
            List<PatientModel> ULst = new List<PatientModel>();
            ULst = PDBA.LOL(orderby, whereclause);
            return Json(new { data = ULst });

        }

        [HttpPost]
        public JsonResult UpdateRecord([FromBody] PatientModel model)
        {
            PDBA.UpdatePatient(model);
            return Json(View(model));
        }

        [HttpPost]
        public JsonResult DeleteRecord([FromBody] PatientModel UM)
        {
            PDBA.DeleteRecord(UM);

            return Json(new { data = UM });

        }

        
    }
}
