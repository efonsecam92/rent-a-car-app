using BackEnd.Model;

namespace BackEnd.BLL
{
    public interface IBLLClientes : IBLLGenerico<Tbl_Cliente>
    {
        void CreateCliente(Tbl_Cliente cliente);
        void UpdateCliente(Tbl_Cliente cliente);
        void DeleteCliente(int idCliente);
    }
}
