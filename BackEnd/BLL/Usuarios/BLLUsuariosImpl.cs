using BackEnd.DAL;
using BackEnd.Model;
using System;

namespace BackEnd.BLL
{
    public class BLLUsuariosImpl : BLLGenericoImpl<Tbl_Usuario>, IBLLUsuarios
    {
        UnidadDeTrabajo<Tbl_Usuario> unit;

        public void CreateUsuario(Tbl_Usuario usuario)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Usuario>(new RentaCarEntities()))
                {
                    usuario.Estado = 1;

                    unit.genericDAL.Add(usuario);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateUsuario(Tbl_Usuario usuario)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Usuario>(new RentaCarEntities()))
                {
                    unit.genericDAL.Update(usuario);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteUsuario(int idUsuario)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Usuario>(new RentaCarEntities()))
                {
                    var v = unit.genericDAL.Get(idUsuario);

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
