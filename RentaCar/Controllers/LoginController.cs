using BackEnd.BLL;
using BackEnd.BLL.Personas;
using BackEnd.Model;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class LoginController : Controller
    {
        private readonly RentaCarEntities context;

        public LoginController()
        {
            context = new RentaCarEntities();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string contrasenia)
        {
            try
            {
                using (context)
                {
                    //string encryptedPass = Encrypt.GetSHA256(contrasenia);

                    var usuario = (from u in context.Tbl_Usuario
                                   join p in context.Tbl_Persona on u.IdPersona equals p.IdPersona
                                   where u.Contrasenia == contrasenia.Trim() && p.Email_Per.Trim() == user
                                   select u).FirstOrDefault();

                    if (usuario == null)
                    {
                        ViewBag.Error = "¡Usuario o contraseña invalidos!";
                        return Login();
                    }

                    Session["User"] = usuario;
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("_Login", "Usuario");
            }
        }
    }
}