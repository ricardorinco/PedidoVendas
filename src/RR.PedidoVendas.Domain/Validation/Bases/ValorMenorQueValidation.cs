namespace RR.PedidoVendas.Domain.Validation.Bases
{
    public class ValorMenorQueValidation
    {
        public static bool Validar(decimal price, decimal valor)
        {
            return price < valor;
        }
    }
}
