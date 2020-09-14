using BackEnd.Model;

namespace BackEnd.BLL
{
    public interface IBLLReservas : IBLLGenerico<Tbl_Reserva>
    {
        void CreateReserva(Tbl_Reserva reserva);
        void UpdateReserva(Tbl_Reserva reserva);
        void DeleteReserva(int idReserva);
    }
}
