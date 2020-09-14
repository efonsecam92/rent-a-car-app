using BackEnd.BLL.Personas;
using BackEnd.Model;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class PersonasController : Controller
    {
        private readonly RentaCarEntities context;
        private readonly IBLLPersonas personaBLL;

        public PersonasController()
        {
            context = new RentaCarEntities();
            personaBLL = new BLLPersonasImpl();
        }

        // GET: Personas
        public ActionResult Index()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }
            try
            {
                List<PersonasViewModel> listaPersonas = new List<PersonasViewModel>();

                List<Tbl_Persona> personas = personaBLL.GetAll();

                foreach (var dato in personas)
                {
                    listaPersonas.Add(new PersonasViewModel
                    {
                        IdPersona = dato.IdPersona,
                        Identificacion = dato.Identificacion,
                        Nombre = dato.Nombre,
                        Apellido1 = dato.Apellido1,
                        Apellido2 = dato.Apellido2,
                        Telefono = dato.Telefono,
                        Email = dato.Email_Per,
                        Direccion = dato.Direccion,
                        Estado = dato.Estado
                    });
                };
                return View(listaPersonas);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            PersonasViewModel personas = new PersonasViewModel();

            return View(personas);
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Identificacion,Nombre,Apellido1,Apellido2,Telefono,Email,Direccion")] PersonasViewModel personas)
        {
            if (ModelState.IsValid)
            {
                personaBLL.CreatePersona(personas.Datos());

                TempData["msg"] = "Exitoso";
                ViewBag.Msg = TempData["msg"];

                return RedirectToAction("Index");
            }

            return View(personas);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int pidPersona, PersonasViewModel personas)
        {
            PersonasViewModel personaVM = personas.PersonaData(personaBLL.Get(pidPersona));

            return View(personaVM);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdPersona,Identificacion,Nombre,Apellido1,Apellido2,Telefono,Email,Direccion,Estado")] PersonasViewModel personas)
        {
            if (ModelState.IsValid)
            {
                personaBLL.UpdatePersona(personas.Datos());

                return RedirectToAction("Index");
            }

            return View(personas);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int pidPersona)
        {
            personaBLL.DeletePersona(pidPersona);

            TempData["msg"] = "Eliminado";
            ViewBag.Msg = TempData["msg"];

            return RedirectToAction("Index", "Personas");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
