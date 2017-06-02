using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Clientes;

namespace RR.PedidoVendas.Domain.Validation.Clientes
{
    public class ClienteConsistenteValidation : Validator<Cliente>
    {
        public ClienteConsistenteValidation()
        {
            var clienteNomeValido = new ClienteNomeValidoSpecification();
            var clienteCPFValido = new ClienteCPFValidoSpecification();

            Add("clienteNomeValido", new Rule<Cliente>(clienteNomeValido, "O nome do cliente deve conter no mínimo 3 caracteres."));
            Add("clienteCPFValido", new Rule<Cliente>(clienteCPFValido, "Informe um CPF válido."));
        }
    }
}
