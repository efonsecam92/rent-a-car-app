using BackEnd.DAL;
using BackEnd.Model;
using System;

namespace BackEnd.BLL
{
    public class BLLClienteImpl : BLLGenericoImpl<Tbl_Cliente>, IBLLClientes
    {
        UnidadDeTrabajo<Tbl_Cliente> unit;

        public void CreateCliente(Tbl_Cliente cliente)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Cliente>(new RentaCarEntities()))
                {
                    cliente.Estado = 1;
                    cliente.Cant_Reservas = 0;

                    unit.genericDAL.Add(cliente);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateCliente(Tbl_Cliente cliente)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Cliente>(new RentaCarEntities()))
                {
                    unit.genericDAL.Update(cliente);
                    unit.Complete();
                }
            }
             catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteCliente(int idCliente)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Cliente>(new RentaCarEntities()))
                {
                    var v = unit.genericDAL.Get(idCliente);

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
