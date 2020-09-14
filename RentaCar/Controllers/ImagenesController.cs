using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.UI.WebControls;
using RentaCar.Models;
using BackEnd.Model;

namespace RentaCar.Controllers
{
    public class ImagenesController : Controller
    {
        // GET: Imagenes
        [HttpGet]
        public ActionResult AddImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImages(ImagenesViewModel image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.Ruta = "~/Content/Resources/img/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Resources/img/"), fileName);
            image.ImageFile.SaveAs(fileName);

            try
            {
                using (RentaCarEntities db = new RentaCarEntities())
                {
                    var img = new Tbl_Imagen();

                    img.Titulo = image.Titulo;
                    img.Ruta = image.Ruta;
                    db.Tbl_Imagen.Add(img);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

            ModelState.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}