using BackEnd.DAL;
using BackEnd.Model;
using System;

namespace BackEnd.BLL
{
    public class BLLReservasImpl : BLLGenericoImpl<Tbl_Reserva>, IBLLReservas
    {
        UnidadDeTrabajo<Tbl_Reserva> unit;

        public void CreateReserva(Tbl_Reserva reserva)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Reserva>(new RentaCarEntities()))
                {
                    unit.genericDAL.Add(reserva);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateReserva(Tbl_Reserva reserva)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Reserva>(new RentaCarEntities()))
                {
                    unit.genericDAL.Update(reserva);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteReserva(int idReserva)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Reserva>(new RentaCarEntities()))
                {
                    var v = unit.genericDAL.Get(idReserva);

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
