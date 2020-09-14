using BackEnd.Model;

namespace BackEnd.BLL
{
    public interface IBLLImagenes : IBLLGenerico<Tbl_Imagen>
    {
        void CreateImagenes(Tbl_Imagen imagen);

        //void UpdateImagenes(Tbl_Imagenes imagen);
        void DeleteImagenes(int idImagen);
    }
}
