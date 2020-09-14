using BackEnd.Model;

namespace BackEnd.BLL.Personas
{
    public interface IBLLPersonas : IBLLGenerico<Tbl_Persona>
    {
        void CreatePersona(Tbl_Persona persona);
        void UpdatePersona(Tbl_Persona persona);
        void DeletePersona(int idPersona);
    }
}
