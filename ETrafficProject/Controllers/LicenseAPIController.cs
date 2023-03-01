using ETrafficProject.Models;
using Microsoft.AspNetCore.Mvc;
using SQLHelper;
using Common.Lib;

namespace ETrafficProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseAPIController : ControllerBase
    {
        [HttpGet]
        public async Task<List<LicenseItemModel>> Index()
        {
            SQLHandlerAsync sqlhelper = new SQLHandlerAsync();
            var thelist = await sqlhelper.ExecuteAsListAsync<LicenseItemModel>("[dbo].[usp_getAlllicense]");
            return thelist;
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

            return Ok();



        }

        [HttpPost]
        public async Task<LicenseItemModel> GetlicenseByDd(int id)
        {
            SQLHandlerAsync sh = new SQLHandlerAsync();
            IList<KeyValue> param = new List<KeyValue>();
            param.Add(new KeyValue("@licenseid", id));
            var details = await sh.ExecuteAsObjectAsync<LicenseItemModel>("[dbo].[usp_license_getbyid]", param);
            return  details;
        }

        [HttpPut]
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
            return Ok();
        }

        [HttpDelete]
        public async Task<OperationResponse<string>> Delete(int id)
        {
            OperationResponse<string> response = new OperationResponse<string>();

            SQLHandlerAsync sqlHelper = new SQLHandlerAsync();
            IList<KeyValue> param = new List<KeyValue>();
            param.Add(new KeyValue("@licenseid", id));
            await sqlHelper.ExecuteNonQueryAsync("[dbo].[usp_delete_license]", param);
            response.Result = "Deleted suucessfully!";
            return response;
        }






    }
}
