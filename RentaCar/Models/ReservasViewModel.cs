using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentaCar.Models
{
    public class ReservasViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReservasViewModel()
        {
            Tbl_Cliente = new HashSet<Tbl_Cliente>();
            Tbl_Empleado = new HashSet<Tbl_Empleado>();
            Tbl_Vehiculo = new HashSet<Tbl_Vehiculo>();
        }

        [Key]
        [Display(Name = "Código de Reserva")]
        public int IdReserva { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar descripción")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "Debe seleccionar un tipo de pago")]
        public string TipoPago { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime FechaEntrega { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Devolución")]
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime FechaDevolucion { get; set; }
        
        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "Debe seleccionar una ciudad.")]
        public string Ciudad { get; set; }

        [Display(Name = "Monto")]
        [RegularExpression("^[0-9-()+]*$", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "Debe ingresar un monto.")]
        public decimal Monto { get; set; }

        [Display(Name = "Cliente a asignar")]
        [Required(ErrorMessage = "Debe seleccionar un cliente.")]
        public int IdCliente { get; set; }

        [Display(Name = "Empleado a asignar")]
        [Required(ErrorMessage = "Debe seleccionar un empleado.")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Vehículo a asignar")]
        [Required(ErrorMessage = "Debe seleccionar un vehículo.")]
        public int IdVehiculo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Cliente> Tbl_Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Empleado> Tbl_Empleado { get; set; }
        public virtual ICollection<Tbl_Vehiculo> Tbl_Vehiculo { get; set; }
    

        //Metodos para CRUD
        public Tbl_Reserva Datos()
        {
            Tbl_Reserva ReservasDB = new Tbl_Reserva
            {
                IdReserva = this.IdReserva,
                Descripcion = this.Descripcion,
                TipoPago = this.TipoPago,
                FechaEntrega = this.FechaEntrega,
                FechaDevolucion = this.FechaDevolucion,
                Ciudad = this.Ciudad,
                Monto = this.Monto,
                IdCliente = this.IdCliente,
                IdEmpleado = this.IdEmpleado,
                IdVehiculo = this.IdVehiculo

            };

            return ReservasDB;
        }

        public ReservasViewModel ReservaData(Tbl_Reserva reserva)
        {
            ReservasViewModel ReservasDB = new ReservasViewModel
            {
                IdReserva = reserva.IdReserva,
                Descripcion = reserva.Descripcion,
                TipoPago = reserva.TipoPago,
                FechaEntrega = reserva.FechaEntrega,
                FechaDevolucion = reserva.FechaDevolucion,
                Ciudad = reserva.Ciudad,
                Monto = reserva.Monto,
                IdCliente = reserva.IdCliente,
                IdEmpleado = reserva.IdEmpleado,
                IdVehiculo = reserva.IdVehiculo
            };

            return ReservasDB;
        }
    }
}