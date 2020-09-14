using BackEnd.DAL;
using BackEnd.Model;
using System;

namespace BackEnd.BLL
{
    public class BLLVehiculosImpl : BLLGenericoImpl<Tbl_Vehiculo>, IBLLVehiculos
    {
        UnidadDeTrabajo<Tbl_Vehiculo> unit;

        public void CreateVehiculo(Tbl_Vehiculo vehiculo)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Vehiculo>(new RentaCarEntities()))
                {
                    vehiculo.Estado = 1;
                    unit.genericDAL.Add(vehiculo);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateVehiculo(Tbl_Vehiculo vehiculo)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Vehiculo>(new RentaCarEntities()))
                {
                    unit.genericDAL.Update(vehiculo);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteVehiculo(int idVehiculo)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Vehiculo>(new RentaCarEntities()))
                {
                    var v = unit.genericDAL.Get(idVehiculo);

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
