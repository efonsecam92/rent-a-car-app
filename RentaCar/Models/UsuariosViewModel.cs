using BackEnd.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentaCar.Models
{
    public class UsuariosViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsuariosViewModel()
        {
            Tbl_Cliente = new HashSet<Tbl_Cliente>();
            Tbl_Empleado = new HashSet<Tbl_Empleado>();
        }

        [Key]
        [Display(Name = "Código de Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Persona Asignada")]
        [Required(ErrorMessage = "Debe seleccionar una persona.")]
        public int IdPersona { get; set; }

        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [Required(ErrorMessage = "Por favor ingrese su correo electrónico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Por favor ingrese su contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales.")]
        [Required(ErrorMessage = "Por favor ingrese su contraseña nuevamente")]
        [DataType(DataType.Password)]
        public string ConfirmLoginPassword { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Cliente> Tbl_Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Empleado> Tbl_Empleado { get; set; }
        public virtual Tbl_Persona Tbl_Persona { get; set; }

        //Metodos para CRUD
        public Tbl_Usuario Datos()
        {
            Tbl_Usuario UsuariosDB = new Tbl_Usuario
            {
                IdUsuario = this.IdUsuario,
                IdPersona = this.IdPersona,
                Email_Comp = this.Email,
                Contrasenia = this.Password,
                Estado = this.Estado
            };

            return UsuariosDB;
        }

        public UsuariosViewModel UsuarioData(Tbl_Usuario usuario)
        {
            UsuariosViewModel usuariosDB = new UsuariosViewModel
            {
                IdUsuario = usuario.IdUsuario,
                IdPersona = usuario.IdPersona,
                Email = usuario.Email_Comp,
                Password = usuario.Contrasenia,
                Estado = usuario.Estado
            };

            return usuariosDB;
        }
    }
}