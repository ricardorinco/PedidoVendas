using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;

namespace RR.PedidoVendas.Domain.Specification.Clientes
{
    public class ClienteCPFValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return ValidarCPF(cliente.CPF);
        }

        private bool ValidarCPF(string cpf)
        {
            try
            {
                int[] primeiroMultiplicador = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] segundoMultiplicador = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    return false;

                string tempCPF = cpf.Substring(0, 9);
                int soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCPF[i].ToString()) * primeiroMultiplicador[i];

                int resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                string digito = resto.ToString();

                tempCPF = tempCPF + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCPF[i].ToString()) * segundoMultiplicador[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }
    }
}
