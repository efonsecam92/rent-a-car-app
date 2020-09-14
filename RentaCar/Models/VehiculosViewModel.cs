using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;

namespace RentaCar.Models
{
    public class VehiculosViewModel
    {
        [Key]
        [Display(Name = "Código de Vehículo")]
        public int IdVehiculo { get; set; }

        [Display(Name = "Placa Vehículo")]
        [Required(ErrorMessage = "Debe ingresar placa del vehículo.")]
        public string Placa { get; set; }

        [Display(Name = "Modelo Vehículo")]
        [Required(ErrorMessage = "Debe ingresar el modelo.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Modelo { get; set; }

        [Display(Name = "Marca Vehículo")]
        [Required(ErrorMessage = "Debe ingresar la marca.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Marca { get; set; }

        [Display(Name = "Color Vehículo")]
        [Required(ErrorMessage = "Debe ingresar el color.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Color { get; set; }

        [Display(Name = "Kilometraje Vehículo.")]
        [Required(ErrorMessage = "Por favor ingrese kilometraje.")]
        public string Kilometraje { get; set; }

        [Display(Name = "Tipo Vehículo")]
        [Required(ErrorMessage = "Por favor ingrese tipo de vehículo.")]
        public string Tipo { get; set; }

        [Display(Name = "Combustible")]
        [Required(ErrorMessage = "Por favor ingrese tipo combustible.")]
        public string TipoCombustible { get; set; }

        [Display(Name = "Imagen")]
        public int? IdImagen { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }

        public string Url { get; set; }
        //Metodos para CRUD

        public Tbl_Vehiculo Datos()
        {
            Tbl_Vehiculo VehiculoDB = new Tbl_Vehiculo
            {
                IdVehiculo = this.IdVehiculo,
                Placa = this.Placa,
                Modelo = this.Modelo,
                Marca = this.Marca,
                Color = this.Color,
                Kilometraje = this.Kilometraje,
                Tipo_Vehiculo = this.Tipo,
                Tipo_Combustible = this.TipoCombustible,
                IdImagen = this.IdImagen,
                Estado = this.Estado
            };

            return VehiculoDB;
        }

        public VehiculosViewModel VehiculoData(Tbl_Vehiculo vehiculo)
        {
            VehiculosViewModel vehiculosDB = new VehiculosViewModel
            {
                IdVehiculo = vehiculo.IdVehiculo,
                Placa = vehiculo.Placa,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Color = vehiculo.Color,
                Kilometraje = vehiculo.Kilometraje,
                Tipo = vehiculo.Tipo_Vehiculo,
                TipoCombustible = vehiculo.Tipo_Combustible,
                IdImagen = vehiculo.IdImagen,
                Estado = vehiculo.Estado
            };
            return vehiculosDB;
        }
    }
}