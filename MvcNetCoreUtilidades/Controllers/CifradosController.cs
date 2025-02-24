using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Helpers;

namespace MvcNetCoreUtilidades.Controllers
{
    public class CifradosController : Controller
    {
        public IActionResult CifradoBasico()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CifradoBasico(string contenido, string resultado, string accion)
        {
            string response = HelperCryptography.EncriptarTextoBasico(contenido);
            if (accion.ToLower() == "cifrar")
            {
                ViewData["TEXTOCIFRADO"] = response;
            } else if (accion.ToLower() == "comparar")
            {
                if (response != resultado)
                {
                    ViewData["MENSAJE"] = "Los datos no coinciden";
                }
                else {
                    ViewData["MENSAJE"] = "Contenidos iguales!";
                        }
            }
            return View();
        }
    }
}
