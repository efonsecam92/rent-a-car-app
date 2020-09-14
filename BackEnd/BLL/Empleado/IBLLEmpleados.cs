using BackEnd.Model;

namespace BackEnd.BLL
{
    public interface IBLLEmpleados : IBLLGenerico<Tbl_Empleado>
    {
        void CreateEmpleado(Tbl_Empleado empleado);
        void UpdateEmpleado(Tbl_Empleado empleado);
        void DeleteEmpleado(int idEmpleado);
    }
}
