using BackEnd.Model;
using System;

namespace BackEnd.DAL
{
    public class UnidadDeTrabajo<TEntity> : IDisposable where TEntity : class
    {
        private readonly RentaCarEntities context;
        public IDALGenerico<TEntity> genericDAL;

        public UnidadDeTrabajo(RentaCarEntities _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<TEntity>(context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
