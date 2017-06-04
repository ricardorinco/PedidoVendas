namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class ValorMaiorQueValidation
    {
        public static bool Validar(decimal preco, decimal valor)
        {
            return preco > valor;
        }
    }
}
