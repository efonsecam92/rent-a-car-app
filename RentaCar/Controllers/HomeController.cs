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
    public class HomeController : Controller
    {
        private readonly RentaCarEntities context;
        private readonly IBLLVehiculos vehiBLL;
        private readonly IBLLImagenes imgBLL;
        public HomeController()
        {
            context = new RentaCarEntities();
            vehiBLL = new BLLVehiculosImpl();
            imgBLL = new BLLImagenImpl();
        }
        public ActionResult Index()
        {
            List<VehiculosViewModel> listaVehiculos = new List<VehiculosViewModel>();

            List<Tbl_Vehiculo> vehiculos = vehiBLL.GetAll();

            foreach (var dato in vehiculos)
            {
                using (RentaCarEntities db = new RentaCarEntities())
                {
                    string url = (from img in db.Tbl_Imagen
                                  where dato.IdImagen == img.IdImagen
                                  select img.Ruta).FirstOrDefault();

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
                        Estado = dato.Estado,
                        Url = url
                    });
                }
            };
            return View(listaVehiculos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}