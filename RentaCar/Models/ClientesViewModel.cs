using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentaCar.Models
{
    public class ClientesViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientesViewModel()
        {
            Tbl_Cliente = new HashSet<Tbl_Cliente>();
            Tbl_Reserva = new HashSet<Tbl_Reserva>();
        }

        [Key]
        [Display(Name = "Código de Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "Persona a asignar")]
        [Required(ErrorMessage = "Debe seleccionar una persona.")]
        public int IdPersona { get; set; }

        [Display(Name = "Fecha Registro")]
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime Fecha_Registro { get; set; }

        [Display(Name = "Cant. Reservas Realizadas")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "Solo se permiten números.")]
        public int? Cant_Reservas { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Tbl_Cliente> Tbl_Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Reserva> Tbl_Reserva { get; set; }
        public virtual Tbl_Persona Tbl_Persona { get; set; }

        //Metodos para CRUD
        public Tbl_Cliente Datos()
        {
            Tbl_Cliente ClienteDB = new Tbl_Cliente
            {
                IdCliente = this.IdCliente,
                IdPersona = this.IdPersona,
                Fecha_Registro = DateTime.Now,
                Cant_Reservas = this.Cant_Reservas,
                Estado = this.Estado
            };

            return ClienteDB;
        }

        public ClientesViewModel ClienteData(Tbl_Cliente cliente)
        {
            ClientesViewModel clientesDB = new ClientesViewModel
            {
                IdCliente = cliente.IdCliente,
                IdPersona = cliente.IdPersona,
                Fecha_Registro = cliente.Fecha_Registro,
                Cant_Reservas = cliente.Cant_Reservas,
                Estado = cliente.Estado
            };

            return clientesDB;
        }
    }
}