using ETrafficProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SQLHelper;

namespace ETrafficProject.Controllers
{
    public class BluebookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            SQLHandlerAsync sh = new SQLHandlerAsync();
            var thelist = await sh.ExecuteAsListAsync<BluebookItemModel>("[dbo].[usp_getAll_bluebook]");
            return View(thelist);
        }
    }
}
