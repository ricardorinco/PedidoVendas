namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class QuantidadeMenorQueValidation
    {
        public static bool Validar(decimal quantidade, decimal valor)
        {
            return quantidade < valor;
        }
    }
}
