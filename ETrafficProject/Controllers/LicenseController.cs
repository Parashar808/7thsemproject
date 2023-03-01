using ETrafficProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using SQLHelper;
using System.Reflection;

namespace ETrafficProject.Controllers
{
    public class LicenseController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SQLHandlerAsync sqlhelper = new SQLHandlerAsync();
            var thelist = await sqlhelper.ExecuteAsListAsync<LicenseItemModel>("[dbo].[usp_getAlllicense]");
            return View(thelist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new LicenseViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LicenseViewModel model)
        {
            SQLHandlerAsync sqlHelper = new SQLHandlerAsync();
            IList<KeyValue> param = new List<KeyValue>();
            param.Add(new KeyValue("@name", model.name));
            param.Add(new KeyValue("@address", model.address));
            param.Add(new KeyValue("@licenseoffice", model.licenseoffice));
            param.Add(new KeyValue("@dob", model.dob));
            param.Add(new KeyValue("@fathername", model.fathername));
            param.Add(new KeyValue("@citizenshipno", model.citizenshipno));
            param.Add(new KeyValue("@contactno", model.contactno));
            param.Add(new KeyValue("@doi", model.doi));
            param.Add(new KeyValue("@doe", model.doe));
            param.Add(new KeyValue("@category", model.category));
            int abc = await sqlHelper.ExecuteNonQueryAsync("[dbo].[usp_addlicense]", param);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetlicenseByDd(int id)
        {
            SQLHandlerAsync sh = new SQLHandlerAsync();
            IList<KeyValue> param = new List<KeyValue>();
            param.Add(new KeyValue("@licenseid", id));
            var details = await sh.ExecuteAsObjectAsync<LicenseItemModel>("[dbo].[usp_license_getbyid]",param);
            return View("Update",details);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LicenseItemModel model)
        {
            SQLHandlerAsync sqlHelper = new SQLHandlerAsync();
            IList<KeyValue> param = new List<KeyValue>();
            param.Add(new KeyValue("@licenseid", model.licenseid));
            param.Add(new KeyValue("@name", model.name));
            param.Add(new KeyValue("@address", model.address));
            param.Add(new KeyValue("@licenseoffice", model.licenseoffice));
            param.Add(new KeyValue("@dob", model.dob));
            param.Add(new KeyValue("@fathername", model.fathername));
            param.Add(new KeyValue("@citizenshipno", model.citizenshipno));
            param.Add(new KeyValue("@contactno", model.contactno));
            param.Add(new KeyValue("@doi", model.doi));
            param.Add(new KeyValue("@doe", model.doe));
            param.Add(new KeyValue("@category", model.category));
            int abc = await sqlHelper.ExecuteNonQueryAsync("[dbo].[usp_updatelicense]", param);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            SQLHandlerAsync sqlHelper = new SQLHandlerAsync();
            IList<KeyValue> param = new List<KeyValue>();
            param.Add(new KeyValue("@licenseid", id));
            int abc = await sqlHelper.ExecuteNonQueryAsync("[dbo].[usp_delete_license]", param);
            return RedirectToAction(nameof(Index));
        }
    }
}
