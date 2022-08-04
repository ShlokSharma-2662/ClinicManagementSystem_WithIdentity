using ASP.NETCoreIdentityCustom.Data;
using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreIdentityCustom.Controllers
{

    public class PrescriptionController : Controller
    {
        PrescriptionDataAccess PDA = new PrescriptionDataAccess();

        public IActionResult AddPrescription()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPrescription([FromBody] PrescriptionModel model)
        {
            {
                PDA.AddPprescription(model);

            }
            return Json(View(model));
        }

        [HttpPost]
        public JsonResult GetStock([FromBody]string MedName)
        {
            List<PrescriptionModel> ULst1 = new List<PrescriptionModel>();
            {
              ULst1 = PDA.GetQuantity(MedName);

            }
            return Json(new {data = ULst1 });
        }

        [HttpGet]
        public JsonResult ViewPrescription(string orderby, string whereclause)
        {
            List<PrescriptionModel> ULst = new List<PrescriptionModel>();

            ULst = PDA.ViewPrescription(orderby, whereclause);

            return Json(new { data = ULst });
        }

        public JsonResult GetDDLMed(string orderby, string whereclause)
        {
            List<MedicineModel> UList = new List<MedicineModel>();
            UList = PDA.GetMedicineDDLData(orderby, whereclause);
            return Json(new { data = UList });
        }

    }
}
