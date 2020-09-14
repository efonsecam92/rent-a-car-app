using BackEnd.DAL;
using BackEnd.Model;
using System;

namespace BackEnd.BLL
{
    public class BLLImagenImpl : BLLGenericoImpl<Tbl_Imagen>, IBLLImagenes
    {
        UnidadDeTrabajo<Tbl_Imagen> unit;

        public void CreateImagenes(Tbl_Imagen imagenes)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Imagen>(new RentaCarEntities()))
                {
                    unit.genericDAL.Add(imagenes);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public void UpdateCliente(Tbl_Cliente cliente)
        //{
        //    try
        //    {
        //        using (unit = new UnidadDeTrabajo<Tbl_Cliente>(new RentaCarEntities()))
        //        {
        //            unit.genericDAL.Update(cliente);
        //            unit.Complete();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public void DeleteImagenes(int idImagen)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Imagen>(new RentaCarEntities()))
                {
                    var v = unit.genericDAL.Get(idImagen);

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
