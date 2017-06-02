namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class ValorValidation
    {
        public static bool Validar(decimal price)
        {
            return price > -0.01m;
        }
    }
}
