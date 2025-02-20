using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Helpers;

namespace MvcNetCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {

        private HelperPathProvider helper;

        public UploadFilesController(HelperPathProvider helper) {
            this.helper = helper;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> SubirFichero(IFormFile fichero)
        {

            string fileName = fichero.FileName;
            string path = this.helper.MapPath(fileName, Folders.Images);
            string urlPath = this.helper.MapUrlPath(fileName, Folders.Images);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }

            ViewData["MENSAJE"] = "Fichero subido a " + path;
            ViewData["URL"] = urlPath;

            return View();
        }

       
    }
}
