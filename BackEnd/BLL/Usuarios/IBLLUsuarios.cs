using BackEnd.Model;

namespace BackEnd.BLL
{
    public interface IBLLUsuarios : IBLLGenerico<Tbl_Usuario>
    {
        void CreateUsuario(Tbl_Usuario usuario);
        void UpdateUsuario(Tbl_Usuario usuario);
        void DeleteUsuario(int idUsuario);
    }
}
