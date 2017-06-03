namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class ValorMaiorQueValidation
    {
        public static bool Validar(decimal price, decimal valor)
        {
            return price > valor;
        }
    }
}
