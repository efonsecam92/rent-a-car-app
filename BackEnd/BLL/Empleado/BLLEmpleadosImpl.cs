using BackEnd.DAL;
using BackEnd.Model;
using System;

namespace BackEnd.BLL
{
    public class BLLEmpleadosImpl : BLLGenericoImpl<Tbl_Empleado>, IBLLEmpleados
    {
        UnidadDeTrabajo<Tbl_Empleado> unit;

        public void CreateEmpleado(Tbl_Empleado empleado)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Empleado>(new RentaCarEntities()))
                {
                    empleado.Estado = 1;

                    unit.genericDAL.Add(empleado);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateEmpleado(Tbl_Empleado empleado)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Empleado>(new RentaCarEntities()))
                {
                    unit.genericDAL.Update(empleado);
                    unit.Complete();
                }
            }
             catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteEmpleado(int idEmpleado)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Empleado>(new RentaCarEntities()))
                {
                    var v = unit.genericDAL.Get(idEmpleado);

                    unit.genericDAL.Remove(v);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
