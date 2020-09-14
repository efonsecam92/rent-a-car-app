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
    public class ClienteController : Controller
    {
        private readonly RentaCarEntities context;
        private readonly IBLLClientes clieBLL;
        private readonly IBLLPersonas perBLL;

        public ClienteController()
        {
            context = new RentaCarEntities();
            perBLL = new BLLPersonasImpl();
            clieBLL = new BLLClienteImpl();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            List<ClientesViewModel> listaClientes = new List<ClientesViewModel>();

            List<Tbl_Cliente> clientes = clieBLL.GetAll();
            foreach (var dato in clientes)
            {
                listaClientes.Add(new ClientesViewModel
                {
                    IdCliente = dato.IdCliente,
                    IdPersona = dato.IdPersona,
                    Cant_Reservas = dato.Cant_Reservas,
                    Fecha_Registro = dato.Fecha_Registro,
                    Estado = dato.Estado
                });
            };

            return View(listaClientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Create()
        {
            DropDown();

            ClientesViewModel clientesVM = new ClientesViewModel();

            return View(clientesVM);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdCliente,IdPersona,Cant_Reservas,Fecha_Registro,Estado")] ClientesViewModel clientes)
        {
            if (ModelState.IsValid)
            {
                clieBLL.CreateCliente(clientes.Datos());

                TempData["msg"] = "Exitoso";
                ViewBag.Msg = TempData["msg"];

                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int idCliente, ClientesViewModel clientes)
        {
            DropDown();

            ClientesViewModel clientesVM = clientes.ClienteData(clieBLL.Get(idCliente));

            return View(clientesVM);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdCliente,IdPersona,Cant_Reservas,Fecha_Registro,Estado")] ClientesViewModel clientes)
        {
            if (ModelState.IsValid)
            {
                clieBLL.UpdateCliente(clientes.Datos());

                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int idCliente)
        {
            clieBLL.DeleteCliente(idCliente);

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
            List<Tbl_Persona> list = perBLL.GetAll();
            ViewBag.Personas = list;
        }

    }
}

