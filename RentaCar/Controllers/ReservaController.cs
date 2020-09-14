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
    public class ReservaController : Controller
    {
        private readonly RentaCarEntities context;
        private readonly IBLLEmpleados empBLL;
        private readonly IBLLClientes clieBLL;
        private readonly IBLLVehiculos vehiBLL;
        private readonly IBLLReservas resBLL;

        public ReservaController()
        {
            context = new RentaCarEntities();
            clieBLL = new BLLClienteImpl();
            vehiBLL = new BLLVehiculosImpl();
            empBLL = new BLLEmpleadosImpl();
            resBLL = new BLLReservasImpl();
        }

        // GET: Reserva
        public ActionResult Index()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            List<ReservasViewModel> listaReservas = new List<ReservasViewModel>();

            List<Tbl_Reserva> reservas = resBLL.GetAll();
            foreach (var dato in reservas)
            {
                listaReservas.Add(new ReservasViewModel
                {
                    IdReserva = dato.IdReserva,
                    Descripcion = dato.Descripcion,
                    TipoPago = dato.TipoPago,
                    FechaEntrega = dato.FechaEntrega,
                    FechaDevolucion = dato.FechaDevolucion,
                    Ciudad = dato.Ciudad,
                    Monto = dato.Monto,
                    IdCliente = dato.IdCliente,
                    IdEmpleado = dato.IdEmpleado,
                    IdVehiculo = dato.IdVehiculo
                });
            };

            return View(listaReservas);
        }

        // GET: Reserva/Create
        public ActionResult Create(int? ID)
        {
            DropDown();

            ReservasViewModel reservaVM = new ReservasViewModel();

            int IdV = Convert.ToInt32(ID);

            if (ID != null)
            {
                reservaVM.IdVehiculo = IdV;
            }

            return View(reservaVM);
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdReserva,Descripcion,TipoPago,FechaEntrega,FechaDevolucion,Ciudad,Monto,IdCliente,IdEmpleado,IdVehiculo")] ReservasViewModel reservas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RentaCarEntities db = new RentaCarEntities())
                    {

                        resBLL.CreateReserva(reservas.Datos());

                        var obj_Vehiculo = db.Tbl_Vehiculo.Find(reservas.IdVehiculo);
                        var obj_Cliente = db.Tbl_Cliente.Find(reservas.IdCliente);

                        obj_Vehiculo.Estado = 0;
                        obj_Cliente.Cant_Reservas = obj_Cliente.Cant_Reservas + 1;

                        db.Entry(obj_Vehiculo).State = System.Data.Entity.EntityState.Modified;
                        db.Entry(obj_Cliente).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                        TempData["msg"] = "Exitoso";
                        ViewBag.Msg = TempData["msg"];

                        return RedirectToAction("Index");
                    }
                }
                return View(reservas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int IdReserva, ReservasViewModel reservas)
        {
            DropDown();

            ReservasViewModel reservasVM = reservas.ReservaData(resBLL.Get(IdReserva));

            return View(reservasVM);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdReserva,Descripcion,TipoPago,FechaEntrega,FechaDevolucion,Ciudad,Monto,IdCliente,IdEmpleado,IdVehiculo")] ReservasViewModel reservas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    resBLL.UpdateReserva(reservas.Datos());

                    return RedirectToAction("Index");
                }
                return View(reservas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int IdReserva)
        {
            try
            {
                using (RentaCarEntities db = new RentaCarEntities())
                {
                    int IdVehiculo = (from r in db.Tbl_Reserva
                                      where r.IdReserva == IdReserva
                                      select r.IdVehiculo).FirstOrDefault();

                    var obj_Vehiculo = db.Tbl_Vehiculo.Find(IdVehiculo);
                    obj_Vehiculo.Estado = 1;
                    db.Entry(obj_Vehiculo).State = System.Data.Entity.EntityState.Modified;

                    resBLL.DeleteReserva(IdReserva);

                    db.SaveChanges();

                    TempData["msg"] = "Eliminado";
                    ViewBag.Msg = TempData["msg"];

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
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
            List<Tbl_Cliente> list = clieBLL.GetAll();
            ViewBag.Clientes = list;

            List<Tbl_Vehiculo> list_ = vehiBLL.GetAll();
            ViewBag.Vehiculos = list_;

            List<Tbl_Empleado> list__ = empBLL.GetAll();
            ViewBag.Empleados = list__;
        }
    }
}
