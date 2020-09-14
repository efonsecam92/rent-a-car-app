using BackEnd.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentaCar.Models
{
    public class PersonasViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonasViewModel()
        {
            Tbl_Usuario = new HashSet<Tbl_Usuario>();
        }

        [Key]
        public int IdPersona { get; set; }

        [Display(Name = "Número de Identificación")]
        [Required(ErrorMessage = "Debe ingresar el número de identificación.")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "Solo se permiten números")]
        //[StringLength(maximumLength: 12, MinimumLength = 9, ErrorMessage = "El número de Identificación debe tener de 9 a 12 digitos según su tipo de identificación")]
        public long Identificacion { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el un nombre .")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "Debe ingresar un apellido.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "Debe ingresar un apellido.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$", ErrorMessage = "Solo se permite ingresar letras")]
        [DataType(DataType.Text)]
        public string Apellido2 { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe ingresar una dirección.")]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [RegularExpression("^[0-9-()+]*$", ErrorMessage = "Solo se permiten números")]
        [StringLength(maximumLength: 15, MinimumLength = 8, ErrorMessage = "El número de teléfono debe ser de 8 digitos")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Display(Name = "Correo Eletrónico")]
        [EmailAddress(ErrorMessage = "El formato del correo eletrónico no es válido")]
        [Required(ErrorMessage = "Debe ingresar una correo electrónico.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Usuario> Tbl_Usuario { get; set; }

        //Metodos para CRUD
        public Tbl_Persona Datos()
        {
            Tbl_Persona PersonasDB = new Tbl_Persona
            {
                IdPersona = IdPersona,
                Identificacion = Identificacion,
                Nombre = Nombre,
                Apellido1 = Apellido1,
                Apellido2 = Apellido2,
                Telefono = Telefono,
                Email_Per = Email,
                Direccion = Direccion,
                Estado = Estado
            };

            return PersonasDB;
        }

        public PersonasViewModel PersonaData(Tbl_Persona persona)
        {
            PersonasViewModel personaDB = new PersonasViewModel
            {
                IdPersona = persona.IdPersona,
                Identificacion =persona.Identificacion,
                Nombre = persona.Nombre,
                Apellido1 = persona.Apellido1,
                Apellido2 = persona.Apellido2,
                Telefono = persona.Telefono,
                Email = persona.Email_Per,
                Direccion = persona.Direccion,
                Estado = persona.Estado
            };

            return personaDB;
        }
    }
}