using BackEnd.Model;

namespace BackEnd.BLL
{
    public interface IBLLVehiculos : IBLLGenerico<Tbl_Vehiculo>
    {
        void CreateVehiculo(Tbl_Vehiculo vehiculo);
        void UpdateVehiculo(Tbl_Vehiculo vehiculo);
        void DeleteVehiculo(int idVehiculo);
    }
}
