using BackEnd.BLL;
using BackEnd.Model;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly RentaCarEntities context;
        private readonly IBLLEmpleados empBLL;
        private readonly IBLLUsuarios userBLL;

        public EmpleadoController()
        {
            context = new RentaCarEntities();
            empBLL = new BLLEmpleadosImpl();
            userBLL = new BLLUsuariosImpl();
        }
        // GET: Empleado
        public ActionResult Index()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }
            List<EmpleadosViewModel> listaEmpleados = new List<EmpleadosViewModel>();

            List<Tbl_Empleado> empleado = empBLL.GetAll();

            foreach (var dato in empleado)
            {
                listaEmpleados.Add(new EmpleadosViewModel
                {
                    IdEmpleado = dato.IdUsuario,
                    Cargo = dato.Cargo,
                    Departamento = dato.Departamento,
                    Jefe_Inmediato = dato.Jefe_Inmediato,
                    IdUsuario = dato.IdUsuario,
                    Estado = dato.Estado
                });
            };

            return View(listaEmpleados);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            DropDown();

            EmpleadosViewModel  empleadosVM = new EmpleadosViewModel();

            return View(empleadosVM);
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdEmpleado,IdUsuario,Jefe_Inmediato,Cargo,Departamento,Estado")] EmpleadosViewModel empleados)
        {
            if (ModelState.IsValid)
            {
                empBLL.CreateEmpleado(empleados.Datos());

                TempData["msg"] = "Exitoso";
                ViewBag.Msg = TempData["msg"];

                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int IdEmpleado, EmpleadosViewModel empleados)
        {
            DropDown();

            EmpleadosViewModel empleadoVM = empleados.EmpleadoData(empBLL.Get(IdEmpleado));

            return View(empleadoVM);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdEmpleado,IdUsuario,Jefe_Inmediato,Cargo,Departamento,Estado")] EmpleadosViewModel empleados)
        {
            if (ModelState.IsValid)
            {
                empBLL.UpdateEmpleado(empleados.Datos());

                return RedirectToAction("Index");
            }

            return View(empleados);
        }
      
        public ActionResult Delete(int IdEmpleado)
        {
            empBLL.DeleteEmpleado(IdEmpleado);

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
           List<Tbl_Usuario> list = userBLL.GetAll();
           ViewBag.Usuarios = list;
        }
    }
}
