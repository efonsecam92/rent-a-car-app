using BackEnd.BLL;
using BackEnd.BLL.Personas;
using BackEnd.Model;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly RentaCarEntities context;
        private readonly IBLLUsuarios userBLL;
        private readonly IBLLPersonas personaBLL;

        public UsuariosController()
        {
            context = new RentaCarEntities();
            userBLL = new BLLUsuariosImpl();
            personaBLL = new BLLPersonasImpl();
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            List<UsuariosViewModel> listaUsuarios = new List<UsuariosViewModel>();

            List<Tbl_Usuario> usuarios = userBLL.GetAll();
            foreach (var dato in usuarios)
            {
                listaUsuarios.Add(new UsuariosViewModel
                {
                    IdUsuario = dato.IdUsuario,
                    IdPersona = dato.IdPersona,
                    Email = dato.Email_Comp,
                    Password = dato.Contrasenia,
                    Estado = dato.Estado
                });
            };

            return View(listaUsuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            DropDown();

            UsuariosViewModel usuariosVM = new UsuariosViewModel();

            return View(usuariosVM);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdPersona,Email,Password,ConfirmLoginPassword")] UsuariosViewModel usuarios)
        {
            if (ModelState.IsValid)
            {
                userBLL.CreateUsuario(usuarios.Datos());

                TempData["msg"] = "Exitoso";
                ViewBag.Msg = TempData["msg"];

                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int pidUsuario, UsuariosViewModel usuarios)
        {
            DropDown();

            UsuariosViewModel usuarioVM = usuarios.UsuarioData(userBLL.Get(pidUsuario));

            return View(usuarioVM);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdUsuario,IdPersona,Email,Password,ConfirmLoginPassword,Estado")] UsuariosViewModel usuarios)
        {
            if (ModelState.IsValid)
            {
                userBLL.UpdateUsuario(usuarios.Datos());

                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int pidUsuario)
        {
            userBLL.DeleteUsuario(pidUsuario);

            TempData["msg"] = "Eliminado";
            ViewBag.Msg = TempData["msg"];

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DropDown()
        {
            List<Tbl_Persona> list = personaBLL.GetAll();
            ViewBag.Personas = list;
        }
    }
}