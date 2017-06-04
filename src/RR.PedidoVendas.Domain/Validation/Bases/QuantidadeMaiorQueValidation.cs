namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class QuantidadeMaiorQueValidation
    {
        public static bool Validar(decimal quantidade, decimal valor)
        {
            return quantidade > valor;
        }
    }
}
