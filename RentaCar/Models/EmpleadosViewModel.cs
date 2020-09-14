using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentaCar.Models
{
    public class EmpleadosViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmpleadosViewModel()
        {
            Tbl_Cliente = new HashSet<Tbl_Cliente>();
            Tbl_Reserva = new HashSet<Tbl_Reserva>();
            Tbl_Usuario = new HashSet<Tbl_Usuario>();
        }

        [Key]
        [Display(Name = "Código de Empleado")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Debe ingresar el cargo.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Cargo { get; set; }

        [Display(Name = "Jefe Inmediato")]
        [Required(ErrorMessage = "Debe ingresar el nombre jefe inmediato.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Jefe_Inmediato { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Debe ingresar el departameto.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Departamento { get; set; }

        [Display(Name = "Usuario a asignar")]
        [Required(ErrorMessage = "Por favor ingrese usuario a asignar.")]
        public int IdUsuario { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }

        public virtual ICollection<Tbl_Cliente> Tbl_Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Reserva> Tbl_Reserva { get; set; }
        public virtual ICollection<Tbl_Usuario> Tbl_Usuario { get; set; }
        public virtual Tbl_Persona Tbl_Persona { get; set; }


        public Tbl_Empleado Datos()
        {
            Tbl_Empleado EmpleadoDB = new Tbl_Empleado
            {
                IdEmpleado = this.IdEmpleado,
                IdUsuario = this.IdUsuario,
                Jefe_Inmediato = this.Jefe_Inmediato,
                Cargo = this.Cargo,
                Departamento = this.Departamento,
                Estado = this.Estado
            };

            return EmpleadoDB;
        }

        public EmpleadosViewModel EmpleadoData(Tbl_Empleado empleado)
        {
            EmpleadosViewModel clientesDB = new EmpleadosViewModel
            {
                IdEmpleado = empleado.IdEmpleado,
                IdUsuario = empleado.IdUsuario,
                Cargo = empleado.Cargo,
                Departamento = empleado.Departamento,
                Jefe_Inmediato = empleado.Jefe_Inmediato,
                Estado = empleado.Estado
            };

            return clientesDB;
        }
    }
}