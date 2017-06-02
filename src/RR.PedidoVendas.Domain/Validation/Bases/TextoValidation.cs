namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class TextoValidation
    {
        public static bool Validar(string texto)
        {
            try
            {
                return texto.Length > 2;
            }
            catch
            {
                return false;
            }
        }
    }
}
