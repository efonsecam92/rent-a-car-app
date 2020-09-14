using BackEnd.BLL;
using BackEnd.BLL.Personas;
using BackEnd.Model;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly RentaCarEntities context;
        private readonly IBLLVehiculos vehiBLL;
        private readonly IBLLImagenes imgBLL;
        public VehiculoController()
        {
            context = new RentaCarEntities();
            vehiBLL = new BLLVehiculosImpl();
            imgBLL = new BLLImagenImpl();
        }

        // GET: Vehiculo
        public ActionResult Index()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            List<VehiculosViewModel> listaVehiculos = new List<VehiculosViewModel>();

            List<Tbl_Vehiculo> vehiculos = vehiBLL.GetAll();

            foreach (var dato in vehiculos)
            {
                listaVehiculos.Add(new VehiculosViewModel
                {
                    IdVehiculo = dato.IdVehiculo,
                    Placa = dato.Placa,
                    Marca = dato.Marca,
                    Modelo = dato.Modelo,
                    Tipo = dato.Tipo_Vehiculo,
                    Kilometraje = dato.Kilometraje,
                    Color = dato.Color,
                    TipoCombustible = dato.Tipo_Combustible,
                    IdImagen = dato.IdImagen,
                    Estado = dato.Estado
                });
            };

            return View(listaVehiculos);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            DropDown();

            VehiculosViewModel vehiculosVM = new VehiculosViewModel();

            return View(vehiculosVM);
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdVehiculo,Placa,Marca,Modelo,Tipo,Kilometraje,Color,TipoCombustible,IdImagen,Estado")] VehiculosViewModel vehiculos)
        {
            if (ModelState.IsValid)
            {
                vehiBLL.CreateVehiculo(vehiculos.Datos());

                TempData["msg"] = "Exitoso";
                ViewBag.Msg = TempData["msg"];

                return RedirectToAction("Index");
            }
            return View(vehiculos);
        }


        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int idVehiculo, VehiculosViewModel vehiculos)
        {
            DropDown();

            VehiculosViewModel vehiculosVM = vehiculos.VehiculoData(vehiBLL.Get(idVehiculo));

            return View(vehiculosVM);
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdVehiculo,Placa,Marca,Modelo,Tipo,Kilometraje,Color,TipoCombustible,IdImagen,Estado")] VehiculosViewModel vehiculos)
        {
            if (ModelState.IsValid)
            {
                vehiBLL.UpdateVehiculo(vehiculos.Datos());

                return RedirectToAction("Index");
            }
            return View(vehiculos);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int idVehiculo)
        {
            vehiBLL.DeleteVehiculo(idVehiculo);

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
            List<Tbl_Imagen> list = imgBLL.GetAll();
            ViewBag.Imagenes = list;
        }
    }
}
