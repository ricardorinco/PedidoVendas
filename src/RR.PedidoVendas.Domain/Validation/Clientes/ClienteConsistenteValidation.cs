using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Clientes;

namespace RR.PedidoVendas.Domain.Validation.Clientes
{
    public class ClienteConsistenteValidation : Validator<Cliente>
    {
        public ClienteConsistenteValidation()
        {
            var clienteNomeMaiorQueValido = new ClienteNomeMaiorQueValidoSpecification();
            var clienteNomeMenorQueValido = new ClienteNomeMenorQueValidoSpecification();
            var clienteCPFValido = new ClienteCPFValidoSpecification();

            Add("clienteNomeMaiorQueValido", new Rule<Cliente>(clienteNomeMaiorQueValido, "O nome do cliente deve conter no mínimo 3 caracteres."));
            Add("clienteNomeMenorQueValido", new Rule<Cliente>(clienteNomeMenorQueValido, "O nome do cliente deve conter no máximo 180 caracteres."));
            Add("clienteCPFValido", new Rule<Cliente>(clienteCPFValido, "Informe um CPF válido."));
        }
    }
}
