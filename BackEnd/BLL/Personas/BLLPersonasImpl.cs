using BackEnd.DAL;
using BackEnd.Model;
using System;

namespace BackEnd.BLL.Personas
{
    public class BLLPersonasImpl : BLLGenericoImpl<Tbl_Persona>, IBLLPersonas
    {
        UnidadDeTrabajo<Tbl_Persona> unit;

        public void CreatePersona(Tbl_Persona persona)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Persona>(new RentaCarEntities()))
                {
                    persona.Estado = 1;

                    unit.genericDAL.Add(persona);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdatePersona(Tbl_Persona persona)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Persona>(new RentaCarEntities()))
                {
                    unit.genericDAL.Update(persona);
                    unit.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletePersona(int idPersona)
        {
            try
            {
                using (unit = new UnidadDeTrabajo<Tbl_Persona>(new RentaCarEntities()))
                {
                    var v = unit.genericDAL.Get(idPersona);

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
