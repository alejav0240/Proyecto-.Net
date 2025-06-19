namespace AlejandroChRProyecto.Client.Services
{
    public class UtilService
    {
        public string obtenerImagen(byte[]? buffer)
        {
            if (buffer == null)
            {
                return "img/no.jpeg";
            }
            else
            {
                return $"data:imagen/png;base64,{Convert.ToBase64String(buffer)}";
            }

        }
    }
}
