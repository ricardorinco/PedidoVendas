namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class TextoMenorQueValidation
    {
        public static bool Validar(string texto, int tamanho)
        {
            try
            {
                return texto.Length < tamanho;
            }
            catch
            {
                return false;
            }
        }
    }
}
