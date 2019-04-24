using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_A.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult login()
        {
            return View();
        }

        //POST: Usuario
        public ActionResult validacion(string usuario, string psw)
        {
            if  usuario == CONEXIONSQLUSUARIO && psw == CONEXIONSQLPSW ;
            {
                return RedirectToAction("Users", "Home", null);
            }

            else
            {
                return MENSAJEDEERROR
            }

            
        }

    }
}