using System;

namespace RR.PedidoVendas.Domain.Validation.Pedidos
{
    // Data de Entrega
    // Data deve maior ou igual a data atual. Obrigatória. 
    public class DataEntregaMaiorIgualAtualValidation
    {
        public static bool Validate(DateTime dataEntrega)
        {
            if (dataEntrega.Date >= DateTime.Now.Date)
                return true;

            return false;
        }
    }
}
